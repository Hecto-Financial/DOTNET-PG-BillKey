using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class delKey_showResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //설정 정보 가져오기
        SettleUtil util = SettleUtil.Instance;
        String LICENSE_KEY = util.LICENSE_KEY;     //라이센스 키
        String SERVER_URL = util.SERVER_URL;       //타겟URL
        String LOG_FILE = util.LOG_FILE;           //로그파일명
        int TIMEOUT = util.TIMEOUT;                //타임아웃


        //요청 파라미터(헤더)
        Dictionary<String, String> REQ_HEADER = new Dictionary<String, String>
        {
            { "mchtId",     String.IsNullOrEmpty(Request.Form["mchtId"]) ? "" : Request.Form["mchtId"] },      //상점아이디
            { "ver",        String.IsNullOrEmpty(Request.Form["ver"]) ? "" : Request.Form["ver"] },         //버전
            { "method",     String.IsNullOrEmpty(Request.Form["method"]) ? "" : Request.Form["method"] },      //결제수단
            { "bizType",    String.IsNullOrEmpty(Request.Form["bizType"]) ? "" : Request.Form["bizType"] },     //업무구분(A1:빌키 삭제)
            { "encCd",      String.IsNullOrEmpty(Request.Form["encCd"]) ? "" : Request.Form["encCd"] },       //암호화구분
            { "mchtTrdNo",  String.IsNullOrEmpty(Request.Form["mchtTrdNo"]) ? "" : Request.Form["mchtTrdNo"] },   //상점주문번호
            { "trdDt",      String.IsNullOrEmpty(Request.Form["trdDt"]) ? "" : Request.Form["trdDt"] },       //요청일자
            { "trdTm",      String.IsNullOrEmpty(Request.Form["trdTm"]) ? "" : Request.Form["trdTm"] },       //요청시간
            { "mobileYn",   String.IsNullOrEmpty(Request.Form["mobileYn"]) ? "" : Request.Form["mobileYn"] },    //모바일여부
            { "osType",     String.IsNullOrEmpty(Request.Form["osType"]) ? "" : Request.Form["osType"] }       //운영체제구분
        };

        //요청 파라미터(바디)
        Dictionary<String, String> REQ_BODY = new Dictionary<String, String>
        {
            { "pktHash",    String.IsNullOrEmpty(Request.Form["pktHash"]) ? "" : Request.Form["pktHash"] },     //해쉬값
            { "billKey",    String.IsNullOrEmpty(Request.Form["billKey"]) ? "" : Request.Form["billKey"] },     //삭제할 빌키(평문 전송, 암호화 대상 아님)
            { "etcInfo",    String.IsNullOrEmpty(Request.Form["etcInfo"]) ? "" : Request.Form["etcInfo"] }      //해지사유코드(선택)
        };

        //응답 파라미터(헤더)
        Dictionary<String, String> RES_HEADER = new Dictionary<String, String>
        {
            { "mchtId", "" },       //상점아이디
            { "ver", "" },          //버전
            { "method", "" },       //결제수단
            { "bizType", "" },      //업무구분
            { "encCd", "" },        //암호화구분
            { "mchtTrdNo", "" },    //상점주문번호
            { "trdNo", "" },        //헥토파이낸셜거래번호
            { "trdDt", "" },        //요청일자
            { "trdTm", "" },        //요청시간
            { "outStatCd", "" },    //거래상태코드
            { "outRsltCd", "" },    //결과코드
            { "outRsltMsg", "" }    //결과메세지
        };

        //응답 파라미터(바디)
        Dictionary<String, String> RES_BODY = new Dictionary<String, String>
        {
            { "pktHash", "" },      //해쉬값
            { "billKey", "" }       //삭제된 빌키
        };


        /** ======================================================================
                                    SHA256 해쉬 처리
            조합필드 : 요청일자 + 요청시간 + 상점아이디 + 상점주문번호 + "0" + 라이센스키
            ※ 빌키 삭제는 거래금액이 없으므로 금액 자리에 반드시 "0"(문자)을 사용합니다.
            ======================================================================   */
        String hashPlain = "";
        String hashCipher = "";
        try
        {
            hashPlain = REQ_HEADER["trdDt"] + REQ_HEADER["trdTm"] + REQ_HEADER["mchtId"] + REQ_HEADER["mchtTrdNo"] + "0" + LICENSE_KEY;
            hashCipher = util.Sha256(hashPlain);
        }
        catch (Exception ex)
        {
            util.LogMessage(LOG_FILE, "[" + REQ_HEADER["mchtTrdNo"] + "][SHA256 HASHING] Hashing Fail! : " + ex.Message);
        }
        finally
        {
            util.LogMessage(LOG_FILE, "[" + REQ_HEADER["mchtTrdNo"] + "][SHA256 HASHING] Plain Text[" + hashPlain + "] ---> Cipher Text[" + hashCipher + "]");
            REQ_BODY["pktHash"] = hashCipher; //해쉬 결과 값 세팅
        }


        /** ======================================================================
                                    AES256 암호화 처리
            빌키 삭제는 암호화 대상 파라미터가 없습니다.
            빌키(billKey)는 평문으로 전송합니다.
            ======================================================================   */


        //URL설정
        String requestUrl = SERVER_URL + "/spay/APICardActionDelkey.do";


        //요청파라미터 세팅
        //params, data 이름은 헥토파이낸셜로 전달되야 하는 값이니 변경하지 마십시오.
        JObject reqParam = new JObject();
        reqParam.Add("params", JObject.FromObject(REQ_HEADER));
        reqParam.Add("data", JObject.FromObject(REQ_BODY));


        /** ======================================================================
                                    API호출(가맹점->헥토파이낸셜) 및 응답 처리
            ======================================================================   */
        Dictionary<String, String> respParam = new Dictionary<String, String>();
        try
        {
            //SendApi( API호출 URL, 전송될데이터, 타임아웃 )
            JObject resp = util.SendApi(requestUrl, reqParam.ToString(), TIMEOUT);

            //응답 파라미터 파싱
            JObject respHeader = resp.ContainsKey("params") ? (JObject)resp["params"] : null;
            JObject respBody = resp.ContainsKey("data") ? (JObject)resp["data"] : null;

            //응답 파라미터 세팅(헤더)
            if (respHeader != null)
            {
                foreach (string k in RES_HEADER.Keys)
                {
                    respParam[k] = respHeader.ContainsKey(k) ? respHeader[k].ToString() : "";
                }
            }
            else
            {
                foreach (string k in RES_HEADER.Keys)
                {
                    respParam[k] = "";
                }
            }

            //응답 파라미터 세팅(바디)
            if (respBody != null)
            {
                foreach (String k in RES_BODY.Keys)
                {
                    respParam[k] = respBody.ContainsKey(k) ? respBody[k].ToString() : "";
                }
            }
            else
            {
                foreach (String k in RES_BODY.Keys)
                {
                    respParam[k] = "";
                }
            }


        }
        catch (Exception ex)
        {
            respParam["outStatCd"] = "0031";
            respParam["outRsltCd"] = "9999";
            respParam["outRsltMsg"] = "[Response Parsing Error]" + ex.Message;
            util.LogMessage(LOG_FILE, "[" + REQ_HEADER["mchtTrdNo"] + "][Response Parsing Error]" + ex.Message);
        }


        /** ======================================================================
                                    화면 출력
            asp:Label 의 Text 는 HTML 인코딩을 하지 않으므로 대입 시점에 인코딩합니다.
            ======================================================================   */
        Label_mchtId.Text       = Server.HtmlEncode(respParam["mchtId"]);
        Label_ver.Text          = Server.HtmlEncode(respParam["ver"]);
        Label_method.Text       = Server.HtmlEncode(respParam["method"]);
        Label_bizType.Text      = Server.HtmlEncode(respParam["bizType"]);
        Label_encCd.Text        = Server.HtmlEncode(respParam["encCd"]);
        Label_mchtTrdNo.Text    = Server.HtmlEncode(respParam["mchtTrdNo"]);
        Label_trdNo.Text        = Server.HtmlEncode(respParam["trdNo"]);
        Label_trdDt.Text        = Server.HtmlEncode(respParam["trdDt"]);
        Label_trdTm.Text        = Server.HtmlEncode(respParam["trdTm"]);
        Label_outStatCd.Text    = Server.HtmlEncode(respParam["outStatCd"]);
        Label_outRsltCd.Text    = Server.HtmlEncode(respParam["outRsltCd"]);
        Label_outRsltMsg.Text   = Server.HtmlEncode(respParam["outRsltMsg"]);
        Label_pktHash.Text      = Server.HtmlEncode(respParam["pktHash"]);
        Label_billKey.Text      = Server.HtmlEncode(respParam["billKey"]);
    }
}
