import { useState } from "react";

import { Link } from "react-router-dom";

function Navbar() {
  const [isOpen, setIsOpen] = useState(false);

  function toggle() {
    setIsOpen(!isOpen);
  }

  return (
    <>
      <header>
        <nav
          className="
          flex flex-wrap
          items-center
          justify-between
          w-full
          py-4
          md:py-0
          px-4
          text-lg text-gray-700
          bg-white
          shadow-md
          mb-3
          fixed
          top-0
          right-0
          left-0"
        >
          <div>
            {/* <a href="/" alt="test"></a> */}
          </div>

          <svg
            xmlns="http://www.w3.org/2000/svg"
            id="menu-button"
            onClick={toggle}
            className="h-6 w-6 cursor-pointer md:hidden block"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              strokeWidth="2"
              d="M4 6h16M4 12h16M4 18h16"
            />
          </svg>

          <div
            className={`${
              isOpen ? "block" : "hidden"
            }  w-full md:flex md:items-center md:w-auto`}
            id="menu"
          >
            <ul
              className="
              pt-4
              text-base text-gray-700
              text-center
              md:flex
              md:justify-between 
              md:pt-0"
            >
              <li>
                <Link
                  to={"/admin"}
                  className="md:p-4 py-2 block hover:text-purple-400"
                  href="#"
                >
                  Dashboard
                </Link>
              </li>

              <li>
                <Link
                  to={"/admin/news"}
                  className="md:p-4 py-2 block hover:text-purple-400"
                  href="#"
                >
                  News
                </Link>
              </li>

              <li>
                <Link
                  to={"/admin/users"}
                  className="md:p-4 py-2 block hover:text-purple-400"
                  href="#"
                >
                  Users
                </Link>
              </li>
            </ul>
          </div>
        </nav>
      </header>
    </>
  );
}

export default Navbar;
