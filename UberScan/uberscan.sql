------------------------------------------------------------
--        Script SQLite  
------------------------------------------------------------


------------------------------------------------------------
-- Table: Publisher
------------------------------------------------------------
CREATE TABLE Publisher(
	publisherID      INTEGER NOT NULL ,
	publisherName    TEXT NOT NULL ,
	nationality      TEXT NOT NULL ,
	creationDate     NUMERIC NOT NULL ,
	headOffice       TEXT NOT NULL ,
	webSite          TEXT NOT NULL,
	CONSTRAINT Publisher_PK PRIMARY KEY (publisherID)
);


------------------------------------------------------------
-- Table: Author
------------------------------------------------------------
CREATE TABLE Author(
	authorID             INTEGER NOT NULL ,
	authorFirstName      TEXT NOT NULL ,
	authorLastName       TEXT NOT NULL ,
	birthDate            NUMERIC NOT NULL ,
	nationality          TEXT NOT NULL ,
	authorDescription    TEXT NOT NULL,
	CONSTRAINT Author_PK PRIMARY KEY (authorID)
);


------------------------------------------------------------
-- Table: FrTranslator
------------------------------------------------------------
CREATE TABLE FrTranslator(
	tranlatorID       INTEGER NOT NULL ,
	translatorName    TEXT NOT NULL,
	CONSTRAINT FrTranslator_PK PRIMARY KEY (tranlatorID)
);


------------------------------------------------------------
-- Table: FavouriteManga
------------------------------------------------------------
CREATE TABLE FavouriteManga(
	favouriteMangaID    INTEGER NOT NULL ,
	userID              INTEGER NOT NULL,
	CONSTRAINT FavouriteManga_PK PRIMARY KEY (favouriteMangaID)
);


------------------------------------------------------------
-- Table: Category
------------------------------------------------------------
CREATE TABLE Category(
	categoryID             INTEGER NOT NULL ,
	categoryLabel          TEXT NOT NULL ,
	categoryDescription    TEXT NOT NULL,
	CONSTRAINT Category_PK PRIMARY KEY (categoryID)
);


------------------------------------------------------------
-- Table: Manga
------------------------------------------------------------
CREATE TABLE Manga(
	mangaID            INTEGER NOT NULL ,
	mangaNameLat       TEXT NOT NULL ,
	mangaNameJap       TEXT NOT NULL ,
	mangaSynopsis      TEXT NOT NULL ,
	publicationDate    NUMERIC NOT NULL ,
	uberScanNote       INTEGER NOT NULL ,
	status             TEXT NOT NULL ,
	publisherID        INTEGER NOT NULL ,
	authorID           INTEGER NOT NULL ,
	tranlatorID        INTEGER NOT NULL ,
	categoryID         INTEGER NOT NULL,
	CONSTRAINT Manga_PK PRIMARY KEY (mangaID)

	,CONSTRAINT Manga_Publisher_FK FOREIGN KEY (publisherID) REFERENCES Publisher(publisherID)
	,CONSTRAINT Manga_Author0_FK FOREIGN KEY (authorID) REFERENCES Author(authorID)
	,CONSTRAINT Manga_FrTranslator1_FK FOREIGN KEY (tranlatorID) REFERENCES FrTranslator(tranlatorID)
	,CONSTRAINT Manga_Category2_FK FOREIGN KEY (categoryID) REFERENCES Category(categoryID)
);


------------------------------------------------------------
-- Table: Volume
------------------------------------------------------------
CREATE TABLE Volume(
	volumeID           INTEGER NOT NULL ,
	volumeNum          INTEGER NOT NULL ,
	volumeSynopsis     TEXT NOT NULL ,
	publicationDate    NUMERIC NOT NULL ,
	linkVolume         TEXT NOT NULL ,
	numberConsult      INTEGER NOT NULL ,
	mangaID            INTEGER NOT NULL,
	CONSTRAINT Volume_PK PRIMARY KEY (volumeID)

	,CONSTRAINT Volume_Manga_FK FOREIGN KEY (mangaID) REFERENCES Manga(mangaID)
);


------------------------------------------------------------
-- Table: Tag
------------------------------------------------------------
CREATE TABLE Tag(
	tagID             INTEGER NOT NULL ,
	tagLabel          TEXT NOT NULL ,
	tagDescription    TEXT NOT NULL,
	CONSTRAINT Tag_PK PRIMARY KEY (tagID)
);


------------------------------------------------------------
-- Table: mangaTags
------------------------------------------------------------
CREATE TABLE mangaTags(
	mangaID    INTEGER NOT NULL ,
	tagID      INTEGER NOT NULL,
	CONSTRAINT relation5_PK PRIMARY KEY (mangaID,tagID)

	,CONSTRAINT relation5_Manga_FK FOREIGN KEY (mangaID) REFERENCES Manga(mangaID)
	,CONSTRAINT relation5_Tag0_FK FOREIGN KEY (tagID) REFERENCES Tag(tagID)
);


------------------------------------------------------------
-- Table: mangaLinkFavourite
------------------------------------------------------------
CREATE TABLE mangaLinkFavourite(
	favouriteMangaID    INTEGER NOT NULL ,
	mangaID             INTEGER NOT NULL,
	CONSTRAINT relation6_PK PRIMARY KEY (favouriteMangaID,mangaID)

	,CONSTRAINT relation6_FavouriteManga_FK FOREIGN KEY (favouriteMangaID) REFERENCES FavouriteManga(favouriteMangaID)
	,CONSTRAINT relation6_Manga0_FK FOREIGN KEY (mangaID) REFERENCES Manga(mangaID)
);


