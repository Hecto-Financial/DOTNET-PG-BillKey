<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cancel_showResult.aspx.cs" Inherits="cancel_showResult" %>
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
        <td>trdDt[취소요청일자]</td>
        <td><asp:Label ID="Label_trdDt" runat="server" /></td>
    </tr>
    <tr>
        <td>trdTm[취소요청시간]</td>
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
        <td>orgTrdNo[원거래번호]</td>
        <td><asp:Label ID="Label_orgTrdNo" runat="server" /></td>
    </tr>
    <tr>
        <td>cnclAmt[취소금액]</td>
        <td><asp:Label ID="Label_cnclAmt" runat="server" /></td>
    </tr>
    <tr>
        <td>blcAmt[취소가능잔액]</td> 
        <td><asp:Label ID="Label_blcAmt" runat="server" /></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center;"><input style="margin-top:20px;" type="button" value="돌아가기" onclick="location.href='cancel_form.aspx'"></td>
    </tr>
    </table>
</div>
</body>
</html>