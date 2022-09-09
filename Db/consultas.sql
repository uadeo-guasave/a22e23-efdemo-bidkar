-- SQLite
select * from Users;

-- GetUserById(int id)
select
    Id,
    Name,
    Firstname || ' ' || Lastname AllName,
    Email
from Users
WHERE
    Id = ?
;