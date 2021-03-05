#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------


#------------------------------------------------------------
# Table: Publisher
#------------------------------------------------------------

CREATE TABLE Publisher(
        publisherID   Int NOT NULL ,
        publisherName Varchar (40) NOT NULL ,
        nationality   Varchar (40) ,
        creationDate  Date NOT NULL ,
        headOffice    Varchar (100) ,
        webSite       Varchar (255)
	,CONSTRAINT Publisher_PK PRIMARY KEY (publisherID)
);


#------------------------------------------------------------
# Table: Author
#------------------------------------------------------------

CREATE TABLE Author(
        authorID          Int NOT NULL ,
        authorFirstName   Varchar (40) NOT NULL ,
        authorLastName    Varchar (40) NOT NULL ,
        birthDate         Date NOT NULL ,
        nationality       Varchar (40) ,
        authorDescription Longtext
	,CONSTRAINT Author_PK PRIMARY KEY (authorID)
);


#------------------------------------------------------------
# Table: FrTranslator
#------------------------------------------------------------

CREATE TABLE FrTranslator(
        tranlatorID    Int NOT NULL ,
        translatorName Varchar (40) NOT NULL
	,CONSTRAINT FrTranslator_PK PRIMARY KEY (tranlatorID)
);


#------------------------------------------------------------
# Table: FavouriteManga
#------------------------------------------------------------

CREATE TABLE FavouriteManga(
        favouriteMangaID Int NOT NULL ,
        userID           Int NOT NULL
	,CONSTRAINT FavouriteManga_PK PRIMARY KEY (favouriteMangaID)
);


#------------------------------------------------------------
# Table: Category
#------------------------------------------------------------

CREATE TABLE Category(
        categoryID          Int NOT NULL ,
        categoryLabel       Varchar (40) NOT NULL ,
        categoryDescription Longtext NOT NULL
	,CONSTRAINT Category_PK PRIMARY KEY (categoryID)
);


#------------------------------------------------------------
# Table: Manga
#------------------------------------------------------------

CREATE TABLE Manga(
        mangaID         Int NOT NULL ,
        mangaNameLat    Varchar (255) ,
        mangaNameJap    Varchar (255) ,
        mangaSynopsis   Longtext ,
        publicationDate Date NOT NULL ,
        uberScanNote    Int NOT NULL ,
        status          Varchar (20) ,
        linkImageManga  Longtext ,
        publisherID     Int NOT NULL ,
        authorID        Int NOT NULL ,
        tranlatorID     Int NOT NULL ,
        categoryID      Int NOT NULL
	,CONSTRAINT Manga_PK PRIMARY KEY (mangaID)

	,CONSTRAINT Manga_Publisher_FK FOREIGN KEY (publisherID) REFERENCES Publisher(publisherID)
	,CONSTRAINT Manga_Author0_FK FOREIGN KEY (authorID) REFERENCES Author(authorID)
	,CONSTRAINT Manga_FrTranslator1_FK FOREIGN KEY (tranlatorID) REFERENCES FrTranslator(tranlatorID)
	,CONSTRAINT Manga_Category2_FK FOREIGN KEY (categoryID) REFERENCES Category(categoryID)
);


#------------------------------------------------------------
# Table: Volume
#------------------------------------------------------------

CREATE TABLE Volume(
        volumeID        Int NOT NULL ,
        volumeNum       Int NOT NULL ,
        volumeSynopsis  Longtext ,
        publicationDate Date NOT NULL ,
        linkVolume      Varchar (255) ,
        numberConsult   Int ,
        linkImageVolume Varchar (255) ,
        mangaID         Int NOT NULL
	,CONSTRAINT Volume_PK PRIMARY KEY (volumeID)

	,CONSTRAINT Volume_Manga_FK FOREIGN KEY (mangaID) REFERENCES Manga(mangaID)
);


#------------------------------------------------------------
# Table: Tag
#------------------------------------------------------------

CREATE TABLE Tag(
        tagID          Int NOT NULL ,
        tagLabel       Varchar (40) NOT NULL ,
        tagDescription Varchar (255) NOT NULL
	,CONSTRAINT Tag_PK PRIMARY KEY (tagID)
);


#------------------------------------------------------------
# Table: MangaTags
#------------------------------------------------------------

CREATE TABLE MangaTags(
        mangaID Int NOT NULL ,
        tagID   Int NOT NULL
	,CONSTRAINT MangaTags_PK PRIMARY KEY (mangaID,tagID)

	,CONSTRAINT MangaTags_Manga_FK FOREIGN KEY (mangaID) REFERENCES Manga(mangaID)
	,CONSTRAINT MangaTags_Tag0_FK FOREIGN KEY (tagID) REFERENCES Tag(tagID)
);


#------------------------------------------------------------
# Table: linkFavouriteManga
#------------------------------------------------------------

CREATE TABLE linkFavouriteManga(
        favouriteMangaID Int NOT NULL ,
        mangaID          Int NOT NULL
	,CONSTRAINT linkFavouriteManga_PK PRIMARY KEY (favouriteMangaID,mangaID)

	,CONSTRAINT linkFavouriteManga_FavouriteManga_FK FOREIGN KEY (favouriteMangaID) REFERENCES FavouriteManga(favouriteMangaID)
	,CONSTRAINT linkFavouriteManga_Manga0_FK FOREIGN KEY (mangaID) REFERENCES Manga(mangaID)
);

