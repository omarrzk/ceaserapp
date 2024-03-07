### Kryptera Text:

1. Öppna Postman.
2. Skapa en ny POST-förfrågan.
3. Ange URL: [http://ceaser-env.eba-njruw8ix.eu-north-1.elasticbeanstalk.com/kryptera](http://ceaser-env.eba-njruw8ix.eu-north-1.elasticbeanstalk.com/kryptera)
4. I "Body"-fliken, välj "raw" och typa in den text du vill kryptera i JSON-format:
   ```json
   {
       "text": "Din_text_att_kryptera"
   }
   ```
5. Tryck på "Send".
6. I svarsfältet kommer du att få den krypterade texten.

### Dekryptera Text:

1. Skapa en ny POST-förfrågan.
2. Ange URL: [http://ceaser-env.eba-njruw8ix.eu-north-1.elasticbeanstalk.com/dekryptera](http://ceaser-env.eba-njruw8ix.eu-north-1.elasticbeanstalk.com/dekryptera)
3. I "Body"-fliken, välj "raw" och typa in den krypterade texten i JSON-format:
   ```json
   {
       "text": "Din_krypterade_text_att_dekryptera"
   }
   ```
4. Tryck på "Send".
5. I svarsfältet kommer du att få den ursprungliga (dekrypterade) texten.
