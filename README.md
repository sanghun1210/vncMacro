# vncMacro 

- 윈도우상에서 웹브라우저 자동화 작업을 수행
- 웹브라우저의 입력 자동화, 출력 확인 등
- C#, winform, chromewebdriver 활용

## 프로젝트 구조

프로젝트는 주로 다음 파일과 디렉토리로 구성됩니다:

- `VncMarco2.sln`: 프로젝트 솔루션 파일.
- `VncMarco2/`: 주요 프로젝트 폴더.
  - `App.config`: 애플리케이션 구성 파일.
  - `BrowserDriver.cs`: 브라우저 드라이버와 관련된 작업을 처리하는 클래스.
  - `Form1.Designer.cs`, `Form1.cs`, `Form1.resx`: 메인 폼과 관련된 사용자 인터페이스 구성 요소.
  - `Program.cs`: 프로그램의 진입점.
  - `Properties/`: 프로젝트 속성 설정.
  - `Scenarios/`: 사용 시나리오를 정의하는 스크립트 및 구성이 위치한 디렉토리.
  - `Sessions/`: 세션 관리와 관련된 데이터가 저장되는 디렉토리.
  - `VncMarco2.csproj`: 프로젝트 파일.
  - `packages.config`: 프로젝트에 필요한 NuGet 패키지 목록.

## 주요 기능

프로젝트는 자동화 작업, 특히 브라우저 기반 작업을 용이하게 하는 여러 컴포넌트로 구성됩니다. 사용자 인터페이스는 `Form1`을 통해 제공되며, 사용자는 여기서 다양한 시나리오를 설정하고 실행할 수 있습니다. `BrowserDriver` 클래스는 브라우저와의 상호작용을 담당하며, `Scenarios` 및 `Sessions` 디렉토리는 사용자가 정의한 작업 시나리오와 세션 정보를 관리합니다.

## 사용 방법

이 프로젝트를 사용하기 위해서는 Visual Studio가 설치되어 있어야 하며, 필요한 NuGet 패키지는 `packages.config`에 정의되어 있으므로, 이를 참고하여 종속성을 해결하면 됩니다.
