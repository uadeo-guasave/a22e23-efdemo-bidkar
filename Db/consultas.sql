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

-- UserLogin(string name, string password)
select
    Id, Name, Firstname, Lastname, Email
from Users
where
    Name = 'bidkar'
and Password = '123456'
;

-- ChangePassword(int id, string newPassword)
update Users set
    Password = ?
where
    Id = ?
;

select * from Profiles;

PRAGMA table_info('Profiles');