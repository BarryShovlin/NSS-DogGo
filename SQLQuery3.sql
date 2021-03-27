SELECT * from Dog

    SELECT d.Id, d.Name AS DogName, d.Breed AS DogBreed, d.Notes AS DogNotes, o.Id AS OwnerId, o.Name AS OwnerName
                            WHEN d.Notes IS NULL THEN 'No notes about this dog'
                        FROM Dog d JOIN Owner o ON o.Id = d.OwnerId
                       