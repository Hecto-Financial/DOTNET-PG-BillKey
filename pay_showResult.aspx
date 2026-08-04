<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pay_showResult.aspx.cs" Inherits="pay_showResult" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>헥토파이낸셜</title>
<style type="text/css">
#STPG_RSLT		{font-family:굴림; font-size:10pt;}
#STPG_RSLT h4	{background-color:#f1f1f1;padding:4px;margin:2px;}
</style>
</head>
<body>
<h3>응답 결과</h3>
<div id="STPG_RSLT"> 
    <table>
     	<tr>
            <td colspan="2" style="text-align: center;"><h4>params</h4></td>
        </tr>
        <tr>
            <td>mchtId[상점아이디]</td>
            <td><asp:Label ID="Label_mchtId" runat="server" /></td>
        </tr>
        <tr>
            <td>ver[버전]</td>
            <td><asp:Label ID="Label_ver" runat="server" /></td>
        </tr>
        <tr>
            <td>method[결제수단]</td>
            <td><asp:Label ID="Label_method" runat="server" /></td>
        </tr>
        <tr>
            <td>bizType[업무구분]</td>
            <td><asp:Label ID="Label_bizType" runat="server" /></td>
        </tr>
        <tr>
            <td>encCd[암호화구분]</td>
            <td><asp:Label ID="Label_encCd" runat="server" /></td>
        </tr>
        <tr>
            <td>mchtTrdNo[상점주문번호]</td>
            <td><asp:Label ID="Label_mchtTrdNo" runat="server" /></td>
        </tr>
        <tr>
            <td>trdNo[헥토파이낸셜 거래번호]</td>
            <td><asp:Label ID="Label_trdNo" runat="server" /></td>
        </tr>
        <tr>
            <td>trdDt[요청일자]</td>
            <td><asp:Label ID="Label_trdDt" runat="server" /></td>
        </tr>
        <tr>
            <td>trdTm[요청시간]</td>
            <td><asp:Label ID="Label_trdTm" runat="server" /></td>
        </tr>
        <tr>
            <td>outStatCd[거래상태코드]</td>
            <td><asp:Label ID="Label_outStatCd" runat="server" /></td>
        </tr>
        <tr>
            <td>outRsltCd[거래결과코드]</td>
            <td><asp:Label ID="Label_outRsltCd" runat="server" /></td>
        </tr>
        <tr>
            <td>outRsltMsg[결과메세지]</td>
            <td><asp:Label ID="Label_outRsltMsg" runat="server" /></td>
        </tr>
     	<tr>
            <td colspan="2" style="text-align: center;"><h4>data</h4></td>
        </tr>
        <tr>
            <td>pktHash[해쉬값]</td>
            <td><asp:Label ID="Label_pktHash" runat="server" /></td>
        </tr>
        <tr>
            <td>trdAmt[거래금액]</td>
            <td><asp:Label ID="Label_trdAmt" runat="server" /></td>
        </tr>

        <tr>
            <td>cardNo[카드번호]</td>
            <td><asp:Label ID="Label_cardNo" runat="server" /></td>
        </tr>
        <tr>
            <td>vldDtYear[유효기간(년)]</td>
            <td><asp:Label ID="Label_vldDtYear" runat="server" /></td>
        </tr>
        <tr>
            <td>vldDtMon[유효기간(월)]</td>
            <td><asp:Label ID="Label_vldDtMon" runat="server" /></td>
        </tr>
        <tr>
            <td>issrId[발급사아이디]</td>
            <td><asp:Label ID="Label_issrId" runat="server" /></td>
        </tr>
        <tr>
            <td>cardNm[카드사명]</td>
            <td><asp:Label ID="Label_cardNm" runat="server" /></td>
        </tr>
        <tr>
            <td>cardKind[카드종류명]</td>
            <td><asp:Label ID="Label_cardKind" runat="server" /></td>
        </tr>
        <tr>
            <td>ninstmtTypeCd[무이자할부타입]</td>
            <td><asp:Label ID="Label_ninstmtTypeCd" runat="server" /></td>
        </tr>
        <tr>
            <td>instmtMon[할부개월수]</td>
            <td><asp:Label ID="Label_instmtMon" runat="server" /></td>
        </tr>
        <tr>
            <td>apprNo[승인번호]</td>
            <td><asp:Label ID="Label_apprNo" runat="server" /></td>
        </tr>
        <tr style="background-color:yellow;">
            <td>billKey[빌키]</td>
            <td><asp:Label ID="Label_billKey" runat="server" /></td>
        </tr>

        <tr>
            <td colspan="2" style="text-align: center;">
            <input type="button" value="돌아가기" style="margin-top:20px;" onclick="location.href='pay_form.aspx'">
            </td>
        </tr>
    </table>
</div>
</body>
</html>