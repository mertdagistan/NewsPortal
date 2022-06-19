import { Routes, Route } from "react-router-dom";

import Navbar from "../../components/Navbar";
import "../../assets/css/output.css";
import Home from "../home";
import NewsDedail from "../newsDetail";
import CategoryNews from "../categoryNews";

function UserLayout(props) {
  return (
    <>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />}></Route>
        <Route path="/news/:key" element={<NewsDedail />}></Route>
        <Route path="/category/:key" element={<CategoryNews />}></Route>
      </Routes>
    </>
  );
}

export default UserLayout;
