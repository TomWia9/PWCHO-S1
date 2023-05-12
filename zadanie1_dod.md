# Tomasz Wiatrowski
## Programowanie Full-Stack w chmurze obliczeniowej - Sprawozdanie 1
### *Aplikacja została napisana z wykorzystaniem języka C#*

## Zadania nieobowiązkowe:

### Zbudować obrazy kontenera z aplikacją opracowaną w punkcie nr 1, które będą pracował na architekturach: linux/arm/v7, linux/arm64/v8 oraz linux/amd64 wykorzystując domyślnie skonfigurowany QEMU w Docker Desktop. 

#### Krok 1: Upewnienie się czy mamy włączoną funkcję buildkit:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/a97ff26f-58f8-4516-91e8-6c4013183872)

#### Krok 2: Utworzenie nowego buildera Buildx:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/6a6e8a54-dd98-4de3-82a2-83003b4fc4c5)

#### Krok 3: Zbudowanie obrazów
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/e8682788-3b79-4ba1-992e-eb11d35e1277)

##### Niestety budowanie obrazu dla linux/arm/v7 oraz linux/arm64/v8 nie działa dla najnowszej wersji frameworka .NET, przy użyciu którego została napisana aplikacja. Budowanie możliwe jest jedynie na platformę linux/amd64.
##### Przykład zbudowania oraz wypchnięcia obrazu do repozytorium DockerHub dla linux/amd64: 
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/c956b932-06b2-4e46-b24c-eb3b2c78689f)
