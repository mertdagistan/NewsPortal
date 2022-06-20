import { lazy } from "react";
import { Routes, Route } from "react-router-dom";

const AdminLayout = lazy(() => import("./pages/Admin/AdminLayout"));
const GuestLayout = lazy(() => import("./pages/User/GuestLayout"));

function App() {
  return (
    <>
      <Routes>
        <Route path="/*" element={<GuestLayout />}></Route>
        <Route path="admin/*" element={<AdminLayout />}></Route>
      </Routes>
    </>
  );
}

export default App;
