# SQL Test Assignment

Attached is a mysqldump of a database to be used during the test.

Below are the questions for this test. Please enter a full, complete, working SQL statement under each question. We do not want the answer to the question. We want the SQL command to derive the answer. We will copy/paste these commands to test the validity of the answer.

**Example:**

_Q. Select all users_

- Please return at least first_name and last_name

SELECT first_name, last_name FROM users;


------

**— Test Starts Here —**

1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields

SELECT *
FROM users
WHERE Id in (2,3,4)

2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium

SELECT first_name, last_name, basic, premium
FROM users u
JOIN (SELECT user_id, sum(CASE WHEN STATUS = 2 THEN 1 ELSE 0 END) AS basic, sum(CASE WHEN STATUS = 3 THEN 1 ELSE 0 END) AS premium
      FROM listings
      GROUP BY user_id) l ON u.id = l.user_id


3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium

SELECT first_name, last_name, basic, premium
FROM users u
JOIN (SELECT user_id, sum(CASE WHEN STATUS = 2 THEN 1 ELSE 0 END) AS basic, sum(CASE WHEN STATUS = 3 THEN 1 ELSE 0 END) AS premium
      FROM listings
      GROUP BY user_id) l ON u.id = l.user_id
WHERE premium > 0


4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue
SELECT first_name, last_name, currency, revenue

FROM users u
JOIN (SELECT user_id, COUNT(price) revenue, currency 
     FROM listings l 
	 JOIN (SELECT * 
		  FROM clicks
		  WHERE YEAR(created) = 2013) c ON l.id = c.listing_id
	 GROUP BY user_id, currency
	) l ON l.user_id = u.id


5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id
INSERT INTO `clicks`
(listing_id,
price,
currency,
created)
VALUES
(
3,
4,
'USD',
sysdate());

SELECT LAST_INSERT_ID();

6. Show listings that have not received a click in 2013
- Please return at least: listing_name

SELECT *
FROM listings
WHERE id NOT IN (SELECT l.id 
     FROM listings l 
	 JOIN (SELECT * 
		  FROM clicks
		  WHERE YEAR(created) = 2013) c ON l.id = c.listing_id
	)


7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected
SELECT year, SUM(total_listings_clicked) as total_listings_clicked, SUM(total_vendors_affected) AS total_vendors_affected
FROM ((SELECT YEAR(created) AS year, count(id) AS total_listings_clicked, 0 AS total_vendors_affected
FROM clicks
GROUP BY YEAR(created))
UNION 
(SELECT YEAR(c.created) AS year, 0 as total_listings_clicked, count(DISTINCT user_id) as total_vendors_affected
FROM users u
JOIN listings l ON u.id = l.user_id
JOIN clicks c ON c.listing_id = l.id
GROUP BY YEAR(c.created))) c
GROUP BY year


8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names
SELECT first_name, last_name, listing_names
FROM users u
JOIN  
	(SELECT user_id,
	GROUP_CONCAT(name) as listing_names 
	FROM listings group by user_id) l ON u.id = l.user_id
WHERE status = 2
