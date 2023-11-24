﻿Feature: MainPageAddImageTests

As a manager
I would like to see that when adding an image to a product, 
the added image is displayed on the page.

Scenario: MP163_1_Searching for a product using an existing article
	Given Product is created
	And Image is added to the created product: '\\TestData\\Images\\image_width_500_height_500.jpeg'
	And Open main page
	And Main page is opened
	When User search product by 'Article'
	And Created product is displayed
	Then Image source is the same as the added image

Scenario: MP163_2_Searching for a product using an existing article
	Given Product is created
	Given Open main page
	Given Main page is opened
	When User search product by 'Article'
	And Created product is displayed
	Then Image source is the same as the default image

Scenario: MP163_3_Searching for a product using an existing article
	Given Product is created
	And Image is added to the created product: '\\TestData\\Images\\image_width_500_height_500.jpeg'
	And New image is added to the created product: '\\TestData\\Images\\image_width_100_height_100.jpeg'
	Given Open main page
	Given Main page is opened
	When User search product by 'Article'
	And Created product is displayed
	Then Image source is the same as the new added image

