<?php
	session_start();

	// Database connection
	function openDatabaseConnection() 
	{
		$options    =   
		[
            PDO::ATTR_EMULATE_PREPARES  =>  false,
            PDO::ATTR_ERRMODE           =>  PDO::ERRMODE_EXCEPTION
        ];

		$db         =   new PDO(DB_TYPE . ':host=' . DB_HOST . ';dbname=' . DB_NAME . ';charset=' . DB_CHARSET, DB_USER, DB_PASS);

		if ( ! empty( $options ) )
		{
		    foreach ( $options as $key => $value )
		    {
		        $db->setAttribute( $key, $value );
		    }
		}
		return $db;

	}

	//Rendering a view means showing up a View eg html part to user or browser. Let's say you have a controller for About page of your site, now from your controller you would render the About view.. which means show the that page in browser for users to see... if you don't, users will see just blank page
	//Think of it echoing html/css/js to browser.
	function render($filename, $data = null)
	{
		if ($data) 
		{
			// call the session control to check the session time!
			require_once(ROOT . "core/sessionControl.php");
			foreach($data as $key => $value) 
			{
				$$key = $value;
			}
		} 

		// header
		require(ROOT . 'view/templates/header.php');
		// the controller calls this.render() function to display the view
		require(ROOT . 'view/' . $filename . '.php');
		// footer
		require(ROOT . 'view/templates/footer.php');

	}