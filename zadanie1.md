# Tomasz Wiatrowski
## Programowanie Full-Stack w chmurze obliczeniowej - Sprawozdanie 1
### *Aplikacja została napisana z wykorzystaniem języka C#*

## Zadania obowiązkowe:

### 1. a) Logi z informacjami o dacie uruchomienia, imieniu i nazwisku autora serwera oraz porcie TCP, na którym serwer nasłuchuje na zgłoszenia klienta.
#### Zrzut ekranu logów:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/efe26fb2-1321-4444-8068-82895f102723)
#### Kod źródłowy:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/8c14a468-ecb8-4a06-9775-8f1a8e9f56c1)

### 1. b) Strona informująca o adresie IP klienta oraz o dacie i godzinie w jego strefie czasowej.
#### Zrzut ekranu strony:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/41eff874-f402-4d74-97c2-7962ea12793d)
#### Kod źródłowy metody pobierającej adres ip:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/ccfc5525-9a34-4549-ad6d-7e91456ce9f2)
#### Kod źródłowy metody pobierającej strefę czasową:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/c0971e8a-2a58-48e4-8a65-12b2fdb2dc8a)
#### Kod źródłowy metody pobierającej datę:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/dbdb6ad6-8647-4f78-b238-61e6ad12578f)
#### Kod źródłowy głównego widoku (index.cshtml)
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/d003cf49-95ab-420c-84f4-2509dd9047f6)

### 2. Plik Dockerfile
#### Link do pliku: [Dockerfile](./Dockerfile)
#### Zrzut ekranu pliku Dockerfile:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/25cde9e9-50ec-4b04-8fe3-7e85661085e4)

### 3. Polecenia Docker

#### a) Zbudowanie opracowanego obrazu kontenera:
##### Aby zbudować opracowany obraz kontenera należy przejść do katalogu zawierającego plik Dockerfile i wykonać polecenie:
  > docker build -t nazwa_obrazu .
##### Zrzut ekranu z przykładem budowania obrazu:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/06fc7b90-16ef-4820-bf8d-00ae67f31039)

#### b) Uruchomienie kontenera na podstawie zbudowanego obrazu:
##### Aby uruchomić kontener na podstawie zbudowanego obrazu należy wykonać polecenie:
  > docker run -p port_hosta:port_kontenera nazwa_obrazu
##### Zrzut ekranu z przykładem uruchomienia kontenera:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/8dad7d0c-a5d5-4003-bbb9-fa795f1189ed)

#### c) Sposób uzyskania informacji, które wygenerował serwer w trakcie uruchamiana kontenera (logi):
##### Aby uzyskać informacje wygenerowane przez serwer w trakcie uruchamiania kontenera, należy wykonać polecenie:
  > docker logs nazwa_kontenera
##### Zrzut ekranu z przykładem uzyskania informacji wygenerowanych przez serwer:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/19f8111d-48e6-4a49-8d51-08fb5fd6a8e2)

#### d) Sprawdzenie, ile warstw posiada zbudowany obraz:
##### Aby sprawdzić ile warstw posiada zbudowany obraz, należy wykonać polecenie:
  > docker history nazwa_obrazu
##### Zrzut ekranu z przykładem sprawdzenia ile warstw posiada zbudowany obraz:
![image](https://github.com/TomWia9/PWCHO-S1/assets/43671686/8602e0e4-8810-495b-b367-a9fcd5651b01)
