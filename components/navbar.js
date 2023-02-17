class Navbar extends HTMLElement {
    constructor() {
      super();
    }
  
    connectedCallback() { 
    this.innerHTML = `
    <style>
    nav 
        {
            background-color: #333;
            overflow: hidden;
        }

/* Style the links inside the navigation bar */
    nav a 
        {
            float: left;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
            font-size: 17px;
        }

/* Change the color of links on hover */
    nav a:hover 
        {
            background-color: #ddd;
            color: black;
        }   
    </style>
    <nav>
        <a onclick = "location.href='index.html'"class="active">Home</a>
        <a href="Navbar/About.html" id="about">About</a>
        <a href="Navbar/EarlyDev.html" id="edev">Early Development</a>
        <a href="Navbar/FutureDev.html" id= "devplan">Development Plan</a>
    </nav>`;
    }
}
  customElements.define('nav-bar-home', Navbar);