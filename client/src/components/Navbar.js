import { useState } from "react";
import { Link } from "react-router-dom";
import Cats from "../data/data.json";

function Navbar() {
  console.log(Cats.categories);

  const [isOpen, setIsOpen] = useState(false);

  const mobileMenu = () => {
    setIsOpen(!isOpen);
  };
  return (
    <div className={(isOpen ? "menu-active" : "")}>
      <nav className="navbar container">
        {/* <div className="logo">
          <img
            src="https://upload.wikimedia.org/wikipedia/commons/2/23/AS_sample_logo.png"
            alt="LOGO"
          />
        </div> */}
        <div className="push-left">
          <button id="menu-toggler" onClick={mobileMenu}>
            <span className="hamburger-line hamburger-line-top"></span>
            <span className="hamburger-line hamburger-line-middle"></span>
            <span className="hamburger-line hamburger-line-bottom"></span>
          </button>

          <ul id="primary-menu" className="menu nav-menu">
            {Cats.categories.map((cat, index) => {
              return (
                <li className="menu-item current-menu-item" key={index}>
                  <Link className="nav__link" to={"/category/" + cat.url}>
                    {cat.name}
                  </Link>
                </li>
              );
            })}
          </ul>
        </div>
      </nav>
    </div>
  );
}

export default Navbar;
