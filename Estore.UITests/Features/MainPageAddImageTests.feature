﻿Feature: MainPageAddImageTests

As a User
I would like to see the product image, 
so that I can choose product

Scenario: MP163_1_Image source after adding image to the product
	Given Product is created
	And Image is added to the created product: '\\TestData\\Images\\image_width_500_height_500.jpeg'
	And Open Main page
	And Main page is opened
	When User search product by 'Article'
	And Created product is displayed
	Then Image source is the same as the added image

Scenario: MP163_2_Image source for the product with the default image 
	Given Product is created
	And Open Main page
	And Main page is opened
	When User search product by 'Article'
	And Created product is displayed
	Then Image source is the same as the default image

Scenario: MP163_3_Image source after adding the first image and then the second one to the product
	Given Product is created
	And Image is added to the created product: '\\TestData\\Images\\image_width_500_height_500.jpeg'
	And New image is added to the created product: '\\TestData\\Images\\image_width_100_height_100.jpeg'
	And Open Main page
	And Main page is opened
	When User search product by 'Article'
	And Created product is displayed
	Then Image source is the same as the new added image