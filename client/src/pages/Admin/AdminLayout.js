import { Route, Routes } from "react-router-dom";
import Navbar from "../../components/Admin/Navbar";
import Dashboard from "../Admin/Dashboard";
import "../../assets/css/output.css";
import News from "../Admin/News";
import Users from "./Users";
import NewsDetail from "./NewsDetail";
function AdminLayout() {
  return (
    <>
      <Navbar />
      <div className="mt-10 p-8">
        <Routes>
          <Route path="/" element={<Dashboard />}></Route>
          <Route path="/news" element={<News />}></Route>
          <Route path="/news/:id" element={<NewsDetail />}></Route>
          <Route path="/users" element={<Users />}></Route>
        </Routes>
      </div>
    </>
  );
}

export default AdminLayout;
