/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50724
Source Host           : localhost:3306
Source Database       : sample05

Target Server Type    : MYSQL
Target Server Version : 50724
File Encoding         : 65001

Date: 2019-11-20 14:27:12
*/

create database sample05 character set utf8;

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for comment
-- ----------------------------
DROP TABLE IF EXISTS `comment`;
CREATE TABLE `comment` (
  `Row_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `ContentId` bigint(20) NOT NULL,
  `Content` varchar(200) DEFAULT NULL,
  `Created` datetime(6) NOT NULL,
  PRIMARY KEY (`Row_id`),
  KEY `FK_Comment_Content_ContentId` (`ContentId`),
  CONSTRAINT `FK_Comment_Content_ContentId` FOREIGN KEY (`ContentId`) REFERENCES `content` (`Row_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of comment
-- ----------------------------
INSERT INTO `comment` VALUES ('1', '1', '评论', '2019-11-20 14:26:36.000000');

-- ----------------------------
-- Table structure for content
-- ----------------------------
DROP TABLE IF EXISTS `content`;
CREATE TABLE `content` (
  `Row_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Title` varchar(20) DEFAULT NULL,
  `Cnt` varchar(1000) DEFAULT NULL,
  `Status` int(11) NOT NULL,
  `Created` datetime(6) NOT NULL,
  `LastUpdate` datetime(6) NOT NULL,
  PRIMARY KEY (`Row_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of content
-- ----------------------------
INSERT INTO `content` VALUES ('1', '标题', '正文', '1', '2019-11-20 14:14:38.000000', '2019-11-20 14:14:42.000000');
