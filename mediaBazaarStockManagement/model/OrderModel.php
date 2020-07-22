<?php
	/**
	 * Method to get all orders
	 * @return [type] [description]
	 */
    function getAllOrders()
    {
        $db = openDatabaseConnection();
		$sql = "SELECT product_order.OrderID, product_order.ProductID, product.Name, product_order.Quantity, product_order.TotalPrice, product.Price, order.OrderDate 
				FROM product_order 
				INNER JOIN product 
				ON product_order.ProductID = product.Id
				INNER JOIN `order`
				ON product_order.OrderID = order.Id
				GROUP BY order.Id;";
		$query = $db->prepare($sql);
		$query->execute();
        $db = null;
		return $query->fetchAll();
    }

    /**
     * Method to get the top 5 best selling products based on orders 
     * @return [type] [description]
     */
    function getOrdersWithMultipleOccuringProducts()
    {
        $db = openDatabaseConnection();
		$sql = "SELECT product_order.OrderID, product_order.ProductID, product.Name, product_order.Quantity, product_order.TotalPrice, product.Price, order.OrderDate 
				FROM product_order 
				INNER JOIN product 
				ON product_order.ProductID = product.Id
				INNER JOIN `order`
				ON product_order.OrderID = order.Id
				GROUP BY product_order.ProductID
				HAVING count(*) >= 5;
				";
		$query = $db->prepare($sql);
		$query->execute();
        $db = null;
		return $query->fetchAll();
    }
?>