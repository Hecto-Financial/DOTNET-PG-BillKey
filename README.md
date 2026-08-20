# DOTNET-PG-BillKey

헥토파이낸셜 신용카드 비/구인증(빌키) API 연동을 위한 .NET 샘플 코드입니다.

## 📋 개요

본 샘플코드는 **API 직접 호출(Non-UI) 방식**이며, 결제창(UI) 방식이 아닙니다.
- 결제창(UI) 방식을 원하실 경우, 표준결제창 연동하시면 됩니다.
- 1회차는 Non-UI 또는 UI 방식으로 취사선택하여 결제하시면 됩니다.
- 2회차 결제는 발급받으신 빌키로 API 직접 호출하여 결제하시면 됩니다.

## 📁 파일 구조

```
/(Project Root)
│  index.html                    <--- 인덱스 페이지
│
│  Web.config                    <--- .NET 웹 설정 파일
│  packages.config               <--- .NET 패키지 설정 파일
│
│  pay_form.aspx                 <--- 결제 API 양식
│  billKey_form.aspx             <--- 빌키 결제 API 양식
│  pay_showResult.aspx           <--- 결제 결과 화면
│  pay_showResult.aspx.cs        <--- 결제 처리 코드페이지
│
│  authAPI_form.aspx             <--- 빌키 발급 API 양식
│  authAPI_showResult.aspx       <--- 빌키 발급 및 결과 출력
│  authAPI_showResult.aspx.cs    <--- 빌키 발급 처리 코드페이지
│
│  cancel_form.aspx              <--- 취소 메인 폼
│  cancel_showResult.aspx        <--- 취소 결과 화면
│  cancel_showResult.aspx.cs     <--- 취소 처리 코드페이지
│
│  receiveNoti.aspx              <--- 결제 완료 후 노티 수신 페이지
│  receiveNoti.aspx.cs           <--- 결제 완료 후 노티 처리 코드페이지
│
├─App_Code/
│      SettleUtil.cs             <--- 헥토파이낸셜 유틸리티 클래스
│
└─Bin/                           <--- 의존성 패키지 위치 (JSON)
        Newtonsoft.Json.dll
        Newtonsoft.Json.dll.refresh
        Newtonsoft.Json.xml
```

## 📄 파일 설명

### 🔧 공통 페이지
- **index.html**: 인덱스 페이지입니다.
- **SettleUtil.cs**: 상점아이디, 암복호화키 등을 설정하며, 유틸성 함수가 들어있는 유틸 클래스입니다.
- **receiveNoti.aspx**: 결제 또는 취소 처리가 완료된 후, 헥토파이낸셜에서 가맹점으로 전달하는 노티(결과통보)를 수신하는 페이지입니다. 전달받은 노티를 활용하여 가맹점의 실제 내부데이터, DB를 처리하시면 됩니다.

### 💳 결제 관련 페이지
- **pay_form.aspx**: 결제 API 양식으로서, 빌키서비스상점의 경우 응답으로 빌키가 발급됩니다.
- **billKey_form.aspx**: 발급받은 빌키로 결제하는 API 양식입니다.
- **pay_showResult.aspx**: 헥토파이낸셜과 Server to Server로 커넥션하여, 결제 요청을 하고 응답을 받아 결과를 출력하는 페이지입니다.
- **authAPI_form.aspx**: 빌키 발급 API 양식으로서, 결제하지 않고 응답으로 빌키가 발급됩니다.
- **authAPI_showResult.aspx**: 헥토파이낸셜과 Server to Server로 커넥션하여, 요청을 하고 응답을 받아 결과를 출력하는 페이지입니다.

### ❌ 취소 관련 페이지
- **cancel_form.aspx**: 취소 요청 시 사용자로부터 정보를 입력받는 Form 페이지입니다.
- **cancel_showResult.aspx**: 헥토파이낸셜과 Server to Server로 커넥션하여, 취소 요청을 하고 응답을 받아 결과를 출력하는 페이지입니다.

## 🔄 페이지 처리 순서

- **결제 API(빌키 발급 포함)**: pay_form.aspx → pay_showResult.aspx
- **빌키 결제**: billKey_form.aspx → pay_showResult.aspx
- **빌키 발급 API**: authAPI_form.aspx → authAPI_showResult.aspx
- **취소 처리 순서**: cancel_form.aspx → cancel_showResult.aspx
- **노티 처리 순서**: receiveNoti.aspx

## ⚙️ SettleUtil.cs 설정 파일 변수 설명

- **PG_MID**: 상점아이디. 테스트환경에서의 상점아이디는 샘플소스에 기재되어 있습니다. 상용테스트 시에는 헥토파이낸셜에서 발급한 MID로 설정하셔야 합니다. 이 값은 외부에 노출되어서는 안됩니다.
- **LICENSE_KEY**: MID당 하나의 라이센스키가 발급됩니다. SHA256 해시체크 용도로 사용됩니다. 이 값은 외부에 노출되어서는 안됩니다.
- **AES256_KEY**: 개인정보/민감정보를 암복호화하는데 사용되는 키로서, 외부에 노출되어서는 안됩니다.
- **SERVER_URL**: 헥토파이낸셜 처리 서버의 URL입니다. 변경하지 마십시오.
- **TIMEOUT**: 헥토파이낸셜 API 통신 연결 타임아웃입니다.
- **LOG_DIR**: 로그파일이 생성되는 디렉터리(없으면 로그파일 생성되지 않습니다.)
- **LOG_FILE**: 일반 거래에 대한 로그 파일명
- **NOTI_LOG_FILE**: 노티 관련 로그 파일명

## 문의

- 기술 문의: pgsupport@hecto.co.kr
- 개발 가이드: [헥토파이낸셜 개발자 센터](https://developers.hectofinancial.co.kr)
