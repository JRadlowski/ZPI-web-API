CREATE TABLE [patrons] (
  [library_card_number] int PRIMARY KEY IDENTITY(1, 1),
  [email] varchar(255) UNIQUE NOT NULL,
  [first_name] varchar(255) NOT NULL,
  [last_name] varchar(255) NOT NULL,
  [date_of_birth] date NOT NULL
)
GO

CREATE TABLE [books] (
  [book_id] int PRIMARY KEY IDENTITY(1, 1),
  [title] varchar(255) NOT NULL,
  [author] varchar(255) NOT NULL,
  [publisher] varchar(255),
  [publication_year] year,
  [isbn] varchar(13) UNIQUE NOT NULL,
  [genre] varchar(255),
  [language] varchar(255),
  [status] varchar(50) NOT NULL
)
GO

CREATE TABLE [rentals] (
  [rental_id] int PRIMARY KEY IDENTITY(1, 1),
  [library_card_number] int NOT NULL,
  [book_id] int NOT NULL,
  [rental_date] date NOT NULL,
  [return_date] date,
  [due_date] date NOT NULL,
  [status] varchar(50) NOT NULL
)
GO

ALTER TABLE [rentals] ADD FOREIGN KEY ([library_card_number]) REFERENCES [patrons] ([library_card_number])
GO

ALTER TABLE [rentals] ADD FOREIGN KEY ([book_id]) REFERENCES [books] ([book_id])
GO
