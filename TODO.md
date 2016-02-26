## Funzionalita
* Creazione nuova gara
* Salvataggio gara attuale automatico su database
* Visualizzazione classifica in tempo reale
* Inserimento risposte delle squadre ai problemi

#### Creazione gara
* Assegnazione di un nome (utilizzato per il salvataggio)
* Inserimento nomi delle squadre
* Inserimento punteggi dei problemi
* Inserimento delle soluzioni dei problemi

#### Visualizzazione classifica
* Viene visualizzata in una finestra separata
* È possibile aprire diverse finestra di visualizzazione della classifica
* Si aggiorna automaticamente quando viene inserita una risposta

#### Inserimento delle risposte
* Si inserisce al risposta data dalla squadra selezionata al problema selezionato
* Se non tutti i dati inseriti sono corretti il pulsante di submit viene disabilitato


## Classi

#### Team
Serve per rappresentare una squadra in gara

* *Problemi*:     vettore dei problemi
* *Nome*:         il nome della squadra
* *GetPunteggio*: ottiene il punteggio attuale della squadra

#### Problema
Rappresenta un problema

* *Valori*:          attributo statico, vettore con i valori dei problemi
* *Risposte*:        attributo statico, vettore con le riposte dei problemi
* *ID*:              indince identificativo del problema
* *Giusto*:          proprieta bool sola lettura, indica se è stata data la risposta giusta
* *GetPunteggio*:    ottiene il punteggio che da visualizzare nella classifica
* *GetPunteggioTot*: ottiene il punteggio totale del problema, compresi gli errori
* *Rispondi*:        metodo per inserire la risposta

#### ContestManager
Gestisce la gara

* *Squadre*:           vettore di team
* *InserisciRisposta*: inserisce la risposta al problema indicato per la squadra indicata

#### WindowClassifica
Mostra la classifica
* *Refresh*: refresha la classifica