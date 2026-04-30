# DOTNET-PG-BillKey

헥토파이낸셜 신용카드 비인증(빌키) API 연동을 위한 .NET 샘플 코드입니다.

> 자세한 연동 방법은 [헥토파이낸셜 개발자 센터](https://developers.hectofinancial.co.kr)를 참고하세요.

---

## 개요

본 샘플코드는 **API 직접 호출(Non-UI) 방식**이며, 결제창(UI) 방식이 아닙니다.

- 1회차 결제 시 Non-UI 또는 UI 방식 중 선택하여 결제하면 됩니다.
- 1회차 결제 응답으로 빌키가 발급됩니다.
- 2회차 이후 결제는 발급받은 빌키로 API를 직접 호출하여 결제합니다.
- 결제창(UI) 방식을 원하실 경우, 표준결제창(DOTNET-PG-SDK)을 사용하세요.

---

## 파일 구조

```
/(Project Root)
│  index.html                    # 인덱스 페이지
│  Web.config                    # .NET 웹 설정 파일
│  packages.config               # .NET 패키지 설정 파일
│
│  pay_form.aspx                 # 결제 요청 폼 (빌키 발급 포함)
│  billKey_form.aspx             # 빌키 결제 요청 폼
│  pay_showResult.aspx           # 결제 결과 화면
│  pay_showResult.aspx.cs        # 결제 처리 코드페이지
│
│  authAPI_form.aspx             # 빌키 발급 전용 API 폼
│  authAPI_showResult.aspx       # 빌키 발급 결과 화면
│  authAPI_showResult.aspx.cs    # 빌키 발급 처리 코드페이지
│
│  cancel_form.aspx              # 취소 요청 폼
│  cancel_showResult.aspx        # 취소 결과 화면
│  cancel_showResult.aspx.cs     # 취소 처리 코드페이지
│
│  receiveNoti.aspx              # 노티 수신 페이지
│  receiveNoti.aspx.cs           # 노티 처리 코드페이지
│
├─App_Code/
│      SettleUtil.cs             # 헥토파이낸셜 유틸리티 클래스 (설정 포함)
│
└─Bin/                           # 의존성 패키지
       Newtonsoft.Json.dll
```

---

## 페이지 처리 순서

| 기능 | 순서 |
|------|------|
| 결제 API (빌키 발급 포함) | `pay_form.aspx` → `pay_showResult.aspx` |
| 빌키 결제 | `billKey_form.aspx` → `pay_showResult.aspx` |
| 빌키 발급 API | `authAPI_form.aspx` → `authAPI_showResult.aspx` |
| 취소 | `cancel_form.aspx` → `cancel_showResult.aspx` |
| 노티 수신 | `receiveNoti.aspx` |

---

## 설정 (SettleUtil.cs)

| 변수 | 설명 |
|------|------|
| `PG_MID` | 상점아이디. 테스트용 MID는 샘플에 포함되어 있으며, 운영 시 발급받은 MID로 교체하세요. **외부 노출 금지** |
| `LICENSE_KEY` | MID별 발급되는 라이센스키. SHA-256 해시 검증에 사용됩니다. **외부 노출 금지** |
| `AES256_KEY` | 개인정보/민감정보 AES-256 암복호화 키. **외부 노출 금지** |
| `SERVER_URL` | 헥토파이낸셜 처리 서버 URL. 테스트/운영 URL 주석 참고 후 변경하세요. |
| `TIMEOUT` | API 통신 연결 타임아웃 (ms) |
| `LOG_DIR` | 로그 파일 저장 디렉터리. 해당 디렉터리가 없으면 로그가 생성되지 않습니다. |
| `LOG_FILE` | 일반 거래 로그 파일명 |
| `NOTI_LOG_FILE` | 노티 관련 로그 파일명 |

---

## 참고

- 테스트 환경: `https://tbgw.settlebank.co.kr`
- 운영 환경: `https://gw.settlebank.co.kr`
- 개발자 센터: [https://developers.hectofinancial.co.kr](https://developers.hectofinancial.co.kr)
