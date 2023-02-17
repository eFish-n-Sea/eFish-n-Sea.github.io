class NavbarNav extends HTMLElement {
    constructor() {
      super();
    }
  
    connectedCallback() { 
    this.innerHTML = `
    <style>
        nav a 
            {
                float: left;
                color: white;
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
                font-size: 17px;
                font-family: "lucida console";
            }

/* Change the color of links on hover */
        nav a:hover 
            {
                background-color: #ddd;
                color: black;
            }

/* Add a color to the active/current link */
        .home:active, .about:active,  .edev:active, .devplan:active
            {
                background-color: #4CAF50;
                color: white;
                cursor: pointer;

            }
    </style>
    <nav>
        <a onclick = "location.href='../index.html'" id ="home">Home</a>
        <a href="../Navbar/About.html" id="about">About</a>
        <a href="../Navbar/EarlyDev.html" id = "edev">Early Development</a>
        <a href="../Navbar/FutureDev.html" id = "devplan">Development Plan</a>
    </nav>`;
    }
}
  customElements.define('nav-bar', NavbarNav);