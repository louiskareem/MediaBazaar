<?php

	/**
	 * Method to get all products
	 * @return [type] [description]
	 */
	function getAllProducts()
	{
		$db = openDatabaseConnection();
		$sql = "SELECT * FROM product";
		$query = $db->prepare($sql);
		$query->execute();
		$db = null;
		return $query->fetchAll();
	}

	/**
	 * Method to get product by ID
	 * @param  [type] $product_id [description]
	 * @return [type]             [description]
	 */
	function getProduct($product_id)
	{
		$db = openDatabaseConnection();
		$sql = "SELECT * FROM product WHERE Id = :product_id";
		$query = $db->prepare($sql);
		$query->execute(array(":product_id" => $product_id));

		$db = null;
		return $query->fetch();
	}

    /**
     * Method to get product by Name
     * @param  [type] $product_name [description]
     * @return [type]             [description]
     */
    function getProductByName($product_name)
    {
        $db = openDatabaseConnection();
        $sql = "SELECT * FROM product WHERE Name = :product_name";
        $query = $db->prepare($sql);
        $query->execute(array(":product_name" => $product_name));

        $db = null;
        return $query->fetch();
    }

	/**
	 * Method to get detailed product information by ID 
	 * @param  [type] $product_id [description]
	 * @return [type]             [description]
	 */
    function getProductInfo($product_id)
    {
        $db = openDatabaseConnection();
        $sql = "SELECT product.*, category.Name AS Category FROM category INNER JOIN product ON category.Id = product.CategoryID 
        WHERE product.Id = :product_id";
        $query = $db->prepare($sql);
        $query->execute(array(":product_id" => $product_id));

        $db = null;

        return $query->fetchAll();  
    }

    /**
     * Method to add product to the DB
     * @param [type] $data [description]
     */
    function addProduct($data)
    {
        $name = $data['name'];
        $description = $data['description'];
        $price = (double)$data['price'];
        $category = getCategory($data['category']);
        $category_id = (int)$category['Id'];
        $quantity = 0;

        $db = openDatabaseConnection();
        $sql = 'INSERT INTO product (Name, Description, Price, CategoryID) VALUES (:name, :description, :price, :category_id)';
        $query = $db->prepare($sql);
        $query->bindValue(":name", $name);
        $query->bindValue(":description", $description);
        $query->bindValue(":price", $price);
        $query->bindValue(":category_id", $category_id);
        $query->execute();
        $latest_id = $db->lastInsertId();

        $sql2 = 'INSERT INTO inventory (UnitsInStock, ProductID) VALUES (:quantity, :last_insert_id)';
        $query = $db->prepare($sql2);
        $query->bindParam(":quantity", $quantity, PDO::PARAM_INT);
        $query->bindValue(":last_insert_id", $latest_id);
        $query->execute();

        $db = null;

        echo "success";
    }

    /**
     * Method to edit a product in the system
     * @param  [type] $data [description]
     * @return [type]       [description]
     */
    function editProduct($data)
    {
        $id = (int)$data['id'];
        $name = $data['name'];
        $price = (double)$data['price'];
        $description = $data['description'];

        $db = openDatabaseConnection();
        $sql = 'UPDATE product SET Name = :name, Description = :description, Price = :price WHERE Id = :id';
        $query = $db->prepare($sql);
        $query->bindValue(":id", $id);
        $query->bindValue(":name", $name);
        $query->bindValue(":description", $description);
        $query->bindValue(":price", $price);
        $query->execute();

        $db = null;
        echo "success";
    }
?>
