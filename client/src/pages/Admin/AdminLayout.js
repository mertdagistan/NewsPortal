import { Route, Routes } from "react-router-dom";
import Navbar from "../../components/Admin/Navbar";
import Dashboard from "../Admin/Dashboard";
import "../../assets/css/output.css";
import Haberler from "../Admin/Haberler";
function AdminLayout() {
  return (
    <>
      <Navbar />
      <div className="mt-16">
        <Routes>
          <Route path="/" element={<Dashboard />}></Route>
          <Route path="/haberler" element={<Haberler />}></Route>
        </Routes>
      </div>
    </>
  );
}

export default AdminLayout;
