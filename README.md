# CeaserAPP

The goal of this task is to create and implement a complete CI/CD chain for an API project in C# with a focus on encryption and decryption.

För att använda ditt Caesar-chiffer-API på länken [http://ceaser-env.eba-njruw8ix.eu-north-1.elasticbeanstalk.com/](http://ceaser-env.eba-njruw8ix.eu-north-1.elasticbeanstalk.com/), följer du dessa steg:

### Kryptera Text:

Skicka en POST-förfrågan till länken `/kryptera` med texten du vill kryptera som en textfil. Använd Content-Type-headern för att ange att du skickar text.

Exempel med cURL:

```bash
curl -X POST http://ceaser-env.eba-njruw8ix.eu-north-1.elasticbeanstalk.com/kryptera \
-H "Content-Type: text/plain" \
-d "Hello, World!"
```

### Dekryptera Text:

Skicka en POST-förfrågan till länken `/dekryptera` med den krypterade texten du vill dekryptera som en textfil. Använd Content-Type-headern för att ange att du skickar text.

Exempel med cURL:

```bash
curl -X POST http://ceaser-env.eba-njruw8ix.eu-north-1.elasticbeanstalk.com/dekryptera \
-H "Content-Type: text/plain" \
-d "Klipk ooxqz!"
```

Dessa förfrågningar returnerar den krypterade respektive dekrypterade texten som svar. Se till att ändra texten i `-d` -flaggan för att matcha den text du vill kryptera eller dekryptera.
