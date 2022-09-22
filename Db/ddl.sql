-- Data Definition Lang
CREATE TABLE Users (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(20) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    Firstname VARCHAR(255) NOT NULL,
    Lastname VARCHAR(255) NOT NULL DEFAULT '-',
    Email VARCHAR(200) NOT NULL UNIQUE,
    RememberToken VARCHAR(255) DEFAULT NULL
);

CREATE TABLE Profiles (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    Avatar VARCHAR(255),
    PublicEmail VARCHAR(200),
    Facebook VARCHAR(50),
    Twitter VARCHAR(50),
    Linkedin VARCHAR(50),
    Description VARCHAR(255),
    UserId INTEGER NOT NULL,
    CONSTRAINT fk_users_profiles
        FOREIGN KEY (UserId)
        REFERENCES Users (Id)
            ON UPDATE CASCADE
            ON DELETE RESTRICT
);