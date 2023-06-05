# Tomasz Wiatrowski
## Programowanie Full-Stack w chmurze obliczeniowej - Sprawozdanie 2
### *Aplikacja została napisana z wykorzystaniem języka C#*

## Zadania obowiązkowe:

### Wykorzystując opracowaną aplikację (kod + Dockerfile) z zadania nr1 należy: 
### a. zbudować, uruchomić i potwierdzić poprawność działania łańcucha Github Actions, który zbuduje obrazy kontenera z tą aplikacją na architektury: linux/arm64/v8 oraz linux/amd64 wykorzystując QEMU

#### W celu stworzenia łańcucha GithubAction utworzono workflow, który przedstawiono na poniższym zrzucie ekranu:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/694bd2b3-51d5-4d93-a441-e2e4e63b4b0f)

#### Link do pliku: [gha.yml](./.github/workflows/gha.yml)

#### Uruchamianie łańucha ustawiono automatycznie na każdy push do brancha master (6, 7 linijka pliku), możliwe jest też manualne urucuhomienie łańcucha (4 linijka pliku).
#### DOCKERHUB_USERNAME i DOCKERHUB_TOKEN zapisane są w sekretach repozytorium. Dane te są niezbędne do autoryzacji do DockerHub.
#### W łańuchu zastosowano również mechanizm cache (30-36, 45-46 oraz 50-53 linijka w pliku).

##### Niestety budowanie obrazu dla linux/arm64/v8 nie działa dla najnowszej wersji frameworka .NET, przy użyciu którego została napisana aplikacja. Budowanie możliwe jest jedynie na platformę linux/amd64. W celu zbudowania obrazu również na linux/arm64/v8 należałoby dodać tę platformę po przecinku w 43 linijce pliku gha.yml.

#### Poniżej przedstawiono proces działania łańcucha GitHub Actions:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/0e51499a-6086-40fc-b5e2-48e8a4666c4b)

#### Łańuch Github Action wrzucił zbudowany plik do repozytorium DockerHub co przedstawia poniższy zrzut ekranu:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/e35aa823-1c49-42e5-849a-ab14f259305b)

Link do repozytorium: [DockerHubRepo](https://hub.docker.com/repository/docker/tomwia9/server-app-zad2/general)


