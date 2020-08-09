
# Farsava -  ASR live Api (WebSocket)

First create an `API KEY` [here](https://panel.amerandish.com/)

## install dependencies

```
dotnet restore
```

## configs
```c#
string baseUrl = "https://api.amerandish.com/v1";
string actionUrl = "/speech/asr";
string authKey = "<YOUR_API_KEY>";

string filePath = @"<YOUR_WAV_FILE_PATH>";
```

## run

```bash
dotnet run
```

