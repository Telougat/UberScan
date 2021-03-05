#  Uberscan  
  
Nous vous présentons le projet  UberScan, le but est simple, c'est une application permettant de lire des scans de manga.  

##  Installation du projet
Pour installer le projet vous devez suivre ces étapes :
- Compiler le projet, à la racine du sous-dossier UberScan entrer la commande suivante : dotnet build
- Démarrer le site, à la racine du sous-dossier UberScan entrer la commande suivante : dotnet run
- Et enfin accéder à la page d'accueil en local dans votre navigateur depuis cette adresse : https://localhost:5001 ou http://localhost:5000

##  Fonctionnalitées  
  
Via l'onglet Manga, vous pouvez voir tous les mangas disponibles sur l'application, si vous en sélectionner un, vous verrez tous les volumes disponibles. Ensuite, si vous cliquez sur un des volumes, une fenêtre s'ouvre avec le scan du volume afin que vous puissiez directement le lire.  
  
Vous pouvez accéder également à l'url /upload  afin d'upload  des scans de manga en PDF.  
  
L'application dispose également d'un chat éphémère totalement fonctionnel, vous pouvez discuter avec d'autres utilisateurs en temps réel, cependant aucun message n'est stockées sur le serveur, donc impossible de retrouver un message particulier ! (ce système est totalement volontaire.)

Malheureusement nous n'avons pas eu le temps d'importer tous les PDF de scans des mangas, mais vous pouvez tout de même tester la fonctionnalité de lecture de scan sur tous les tomes de Dr.Stone et de Dragon ball qui sont disponibles.

Et pour finir, vous pouvez filtrer les mangas par nom dans la petite barre de recherche se situant sur la page de mangas disponibles.
  
###  Routes  
  
Vous pourrez accéder à toutes les routes depuis l'interface hormis une seule qui  est /author  que vous devez taper directement dans l'URL.

### Réalisations par Enzo JURET, Lorenzo LAGOUTTE, Kevin LEHOUX, Timothé LAINE.
