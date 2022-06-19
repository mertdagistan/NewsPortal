import { Routes, Route } from "react-router-dom";

import Navbar from "../../components/Navbar";
import "../../assets/css/output.css";
import Home from "./Home";
import NewsDedail from "./NewsDetail";
import CategoryNews from "./CategoryNews";

function UserLayout() {
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
