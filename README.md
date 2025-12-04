# Library Management System  
**ASP.NET Core MVC + Entity Framework Core + Service Pattern + Email Notifications**

Un sistema completo per la gestione di una biblioteca, sviluppato in **ASP.NET Core MVC** con **Entity Framework Core** e design basato su **Service Pattern**.  
Il progetto permette di gestire libri, autori, categorie, prestiti e inviare email di conferma tramite **Mailtrap SMTP**.

---

## Funzionalità Principali

### Gestione Libri
- Visualizzazione lista libri
- Aggiunta di nuovi libri
- Modifica dei dettagli
- Eliminazione libri
- Upload copertina
- Associazione ad autore e categoria
- Stato disponibilità (Disponibile / In prestito)

### Gestione Autori
- CRUD completo (Create, Read, Update, Delete)

### Gestione Categorie
- CRUD completo

### Gestione Prestiti
- Prestare un libro con email di conferma
- Data di scadenza prestito
- Restituzione libro
- Lista dei prestiti

### Email Notification (Mailtrap)
Ogni volta che un utente prende in prestito un libro, il sistema:
- Invia una email HTML di conferma  
- Mostra titolo, autore, data di scadenza  
- Utilizza FluentEmail con Mailtrap SMTP

---

## Architettura del Progetto

### 🔹 ASP.NET Core MVC  
Utilizzato per routing, controller, views e rendering lato server.

###  Entity Framework Core  
- Code-first  
- Migrazioni automatiche  
- Relazioni tra tabelle  
- Seed iniziale (autori, categorie, libri)

###  Service Pattern  
Ogni area è separata in servizi


### Autore

Riccardo Reali
