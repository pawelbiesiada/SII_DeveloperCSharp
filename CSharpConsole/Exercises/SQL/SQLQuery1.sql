SELECT Id, Name, Password, IsActive 
FROM Users
WHERE Name LIKE 'J%' AND IsActive = 1 -- just active users

SELECT * FROM Groups




SELECT COUNT(*) FROM USERS

SELECT users.Name 'UserName', groups.Name 'GroupName'
FROM users
JOIN UserGroups
  ON users.Id = UserGroups.UserId
JOIN Groups
  ON groups.Id = UserGroups.GroupId

--UPDATE Users 
--SET IsActive = 1
--WHERE Id = 1

--INSERT

--DELETE