CREATE DATABASE travelbookingdb;

USE travelbookingdb;
Drop table flt01
Drop table hlt01
drop table bok01
drop table usr01
-- Flights Table
CREATE TABLE flt01 (
    t01f01 INT AUTO_INCREMENT PRIMARY KEY,  -- flight_id
    t01f02 VARCHAR(50) UNIQUE NOT NULL COMMENT 'flight_number',    -- flight_number
    t01f03 VARCHAR(100) NOT NULL COMMENT 'departure_city',         -- departure_city
    t01f04 VARCHAR(100) NOT NULL COMMENT 'arrival_city',           -- arrival_city
    t01f05 DATETIME NOT NULL COMMENT 'departure_time',             -- departure_time
    t01f06 DATETIME NOT NULL COMMENT 'arrival_time',               -- arrival_time
    t01f07 DECIMAL(18,2) NOT NULL COMMENT 'price',                 -- price
    t01f08 VARCHAR(100) NOT NULL COMMENT 'airline',                -- airline
    t01f09 DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'created_at', -- created_at
    t01f10 DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'updated_at' -- updated_at
);


-- Hotels Table
CREATE TABLE htl01 (
    l01f01 INT AUTO_INCREMENT PRIMARY KEY,  -- hotel_id
    l01f02 VARCHAR(100) NOT NULL COMMENT 'hotel_name',             -- hotel_name
    l01f03 VARCHAR(100) NOT NULL COMMENT 'city',                   -- city
    l01f04 DECIMAL(18,2) NOT NULL COMMENT 'price_per_night',       -- price_per_night
    l01f05 FLOAT NOT NULL COMMENT 'rating',                         -- rating
    l01f06 INT NOT NULL COMMENT 'available_rooms',                 -- available_rooms
    l01f07 DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'created_at', -- created_at
    l01f08 DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'updated_at' -- updated_at
);


-- Bookings Table
CREATE TABLE bok01 (
    k01f01 INT AUTO_INCREMENT PRIMARY KEY,  -- booking_id
    k01f02 VARCHAR(100) NOT NULL COMMENT 'customer_name',          -- customer_name
    k01f03 VARCHAR(100) NOT NULL COMMENT 'email',                  -- email
    k01f04 DATETIME NOT NULL COMMENT 'booking_date',               -- booking_date
    k01f05 VARCHAR(50) NOT NULL COMMENT 'type (flight or hotel)',  -- type (flight or hotel)
    k01f06 INT NOT NULL COMMENT 'reference_id (flight_id or hotel_id)', -- reference_id (flight_id or hotel_id)
    k01f07 DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'created_at', -- created_at
    k01f08 DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'updated_at', -- updated_at
    CONSTRAINT fk_reference_id FOREIGN KEY (k01f06)
        REFERENCES flt01(t01f01) ON DELETE CASCADE -- for flight bookings
);

Drop table usr01
-- User Table
CREATE TABLE usr01 (
    r01f01 INT AUTO_INCREMENT PRIMARY KEY,  -- user_id
    r01f02 VARCHAR(100) UNIQUE NOT NULL COMMENT 'username',         -- username
    r01f03 VARCHAR(255) NOT NULL COMMENT 'password_hash',           -- password_hash
    r01f04 VARCHAR(100) NOT NULL COMMENT 'email',                  -- email
    r01f05 varchar(50) NOT NULL COMMENT 'role (Admin or User)',  -- role (Admin or User)
    r01f06 DATETIME NOT NULL  COMMENT 'created_at', -- created_at
    r01f07 DATETIME ON UPDATE CURRENT_TIMESTAMP COMMENT 'updated_at' -- updated_at
);

