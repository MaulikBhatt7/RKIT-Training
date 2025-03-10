var menuData = [
  { id: '1', name: 'Fruits', icon: 'food', items: [{ id: '1_1', name: 'Apple', price: 3, image: 'https://upload.wikimedia.org/wikipedia/commons/1/15/Red_Apple.jpg', description: 'Fresh Red Apples' }] },
  { id: '2', name: 'Vegetables', icon: 'leaf', items: [{ id: '2_1', name: 'Carrot', price: 2, image: 'https://upload.wikimedia.org/wikipedia/commons/a/a2/Carrot.jpg', description: 'Fresh Carrots' }] },
  { id: '3', name: 'Beverages', icon: 'coffee', items: [{ id: '3_1', name: 'Green Tea', price: 5, image: 'https://upload.wikimedia.org/wikipedia/commons/3/3b/Loose_leaf_green_tea.jpg', description: 'Refreshing Green Tea' }] },
  { id: '4', name: 'Bakery', icon: 'cart', items: [{ id: '4_1', name: 'Bread', price: 3, image: 'https://upload.wikimedia.org/wikipedia/commons/d/d5/Bread_in_Brussels.JPG', description: 'Whole Wheat Bread' }] },
  { id: '5', name: 'Dairy', icon: 'box', items: [{ id: '5_1', name: 'Milk', price: 2, image: 'https://upload.wikimedia.org/wikipedia/commons/6/6e/Milk_glass.jpg', description: 'Fresh Cow Milk' }] },
  { id: '6', name: 'Fast Food', icon: 'car', items: [{ id: '6_1', name: 'Pizza', price: 8, image: 'https://upload.wikimedia.org/wikipedia/commons/d/d3/Supreme_pizza.jpg', description: 'Cheese & Pepperoni Pizza' }] },
  { id: '7', name: 'Desserts', icon: 'star', items: [{ id: '7_1', name: 'Chocolate Cake', price: 5, image: 'https://upload.wikimedia.org/wikipedia/commons/0/02/Chocolate_cake_with_chocolate_icing.jpg', description: 'Rich Chocolate Cake' }] },
  { id: '8', name: 'Books', icon: 'book', items: [{ id: '8_1', name: 'Fiction', price: 15, image: 'https://upload.wikimedia.org/wikipedia/commons/d/d4/Bookshelf.jpg', description: 'Bestselling Fiction' }] },
  { id: '9', name: 'Electronics', icon: 'preferences', items: [{ id: '9_1', name: 'Smartphone', price: 699, image: 'https://upload.wikimedia.org/wikipedia/commons/3/3e/IPhone_14.jpg', description: 'Latest Smartphone' }] },
  { id: '10', name: 'Clothing', icon: 'runner', items: [{ id: '10_1', name: 'T-Shirt', price: 20, image: 'https://upload.wikimedia.org/wikipedia/commons/6/66/T-shirt.svg', description: 'Comfortable Cotton T-Shirt' }] },
  { id: '11', name: 'Shoes', icon: 'car', items: [{ id: '11_1', name: 'Sneakers', price: 50, image: 'https://upload.wikimedia.org/wikipedia/commons/b/b5/Running_shoes_asics.JPG', description: 'Stylish Sneakers' }] },
  { id: '12', name: 'Jewelry', icon: 'star', items: [{ id: '12_1', name: 'Gold Ring', price: 299, image: 'https://upload.wikimedia.org/wikipedia/commons/4/40/Gold_Ring.jpg', description: 'Elegant Gold Ring' }] },
  { id: '13', name: 'Furniture', icon: 'home', items: [{ id: '13_1', name: 'Sofa', price: 500, image: 'https://upload.wikimedia.org/wikipedia/commons/8/87/Sofa.jpg', description: 'Comfortable Sofa' }] },
  { id: '14', name: 'Toys', icon: 'smiley', items: [{ id: '14_1', name: 'Teddy Bear', price: 25, image: 'https://upload.wikimedia.org/wikipedia/commons/7/77/Teddy_bear.jpg', description: 'Soft Teddy Bear' }] },
  { id: '15', name: 'Sports', icon: 'runner', items: [{ id: '15_1', name: 'Football', price: 30, image: 'https://upload.wikimedia.org/wikipedia/commons/a/a5/Soccer_ball.svg', description: 'Official Size Football' }] },
  { id: '16', name: 'Pet Supplies', icon: 'box', items: [{ id: '16_1', name: 'Dog Food', price: 40, image: 'https://upload.wikimedia.org/wikipedia/commons/a/a2/Dog_food.jpg', description: 'Nutritious Dog Food' }] },
  { id: '17', name: 'Office Supplies', icon: 'preferences', items: [{ id: '17_1', name: 'Notebook', price: 10, image: 'https://upload.wikimedia.org/wikipedia/commons/7/7f/Notebook.jpg', description: 'Spiral Notebook' }] },
  { id: '18', name: 'Automobiles', icon: 'car', items: [{ id: '18_1', name: 'Car Tire', price: 100, image: 'https://upload.wikimedia.org/wikipedia/commons/7/70/Tire_1509.JPG', description: 'Durable Car Tire' }] },
  { id: '19', name: 'Beauty Products', icon: 'smiley', items: [{ id: '19_1', name: 'Lipstick', price: 15, image: 'https://upload.wikimedia.org/wikipedia/commons/6/6c/Lipstick_Colors.jpg', description: 'Matte Lipstick' }] },
  { id: '20', name: 'Gardening', icon: 'leaf', items: [{ id: '20_1', name: 'Flower Seeds', price: 5, image: 'https://upload.wikimedia.org/wikipedia/commons/e/ec/Seeds_of_Flowering_Plant.jpg', description: 'Organic Flower Seeds' }] },
  { id: '21', name: 'Home Decor', icon: 'home', items: [{ id: '21_1', name: 'Wall Clock', price: 35, image: 'https://upload.wikimedia.org/wikipedia/commons/6/6d/Wall_clock.jpg', description: 'Stylish Wall Clock' }] },
  { id: '22', name: 'Kitchen Appliances', icon: 'preferences', items: [{ id: '22_1', name: 'Blender', price: 60, image: 'https://upload.wikimedia.org/wikipedia/commons/4/49/Blender.jpg', description: 'High-Speed Blender' }] },
  { id: '23', name: 'Health', icon: 'box', items: [{ id: '23_1', name: 'Vitamin C', price: 20, image: 'https://upload.wikimedia.org/wikipedia/commons/5/50/Vitamin_C_tablets.jpg', description: 'Immune Booster' }] },
  { id: '24', name: 'Music Instruments', icon: 'star', items: [{ id: '24_1', name: 'Guitar', price: 120, image: 'https://upload.wikimedia.org/wikipedia/commons/4/45/Guitar.jpg', description: 'Acoustic Guitar' }] },
  { id: '25', name: 'Baby Products', icon: 'smiley', items: [{ id: '25_1', name: 'Diapers', price: 30, image: 'https://upload.wikimedia.org/wikipedia/commons/3/3e/Diapers.jpg', description: 'Soft Diapers' }] },
  { id: '26', name: 'Travel', icon: 'car', items: [{ id: '26_1', name: 'Backpack', price: 50, image: 'https://upload.wikimedia.org/wikipedia/commons/1/11/Backpack.jpg', description: 'Durable Travel Backpack' }] },
];





let menuItems = [
  { name: "Home", icon: "home" },
  { 
      name: "Services", 
      icon: "preferences", 
      items: [
          { name: "Web Development" },
          { name: "Mobile Development" }
      ] 
  },
  { name: "About", icon: "info" },
  { name: "Contact", icon: "tel" }
];


var menuData2 = [
  {
    id: '1',
    name: 'Fruits',
    items: [
      { id: '1_1', name: 'Apple', price: 3 },
      { id: '1_2', name: 'Banana', price: 1 },
      { id: '1_3', name: 'Mango', price: 2.5 },
    ],
  },
  {
    id: '2',
    name: 'Vegetables',
    items: [
      { id: '2_1', name: 'Carrot', price: 2 },
      { id: '2_2', name: 'Broccoli', price: 2.8 },
      { id: '2_3', name: 'Spinach', price: 1.5 },
    ],
  },
  {
    id: '3',
    name: 'Beverages',
    items: [
      {
        id: '3_1',
        name: 'Tea',
        expanded: true,
        items: [
          { id: '3_1_1', name: 'Green Tea', price: 5 },
          { id: '3_1_2', name: 'Black Tea', price: 4.5 },
        ],
      },
      {
        id: '3_2',
        name: 'Juices',
        items: [
          { id: '3_2_1', name: 'Orange Juice', price: 6 },
          { id: '3_2_2', name: 'Apple Juice', price: 5.5 },
        ],
      },
    ],
  },
  {
    id: '4',
    name: 'Bakery',
    items: [
      { id: '4_1', name: 'Bread', price: 3 },
      { id: '4_2', name: 'Croissant', price: 2.5 },
      { id: '4_3', name: 'Muffin', price: 2.8 },
    ],
  },
];