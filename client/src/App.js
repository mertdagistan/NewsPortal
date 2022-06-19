import { lazy } from "react";
import { Routes, Route } from "react-router-dom";

const AdminLayout = lazy(() => import("./pages/Layouts/adminLayout"));
const UserLayout = lazy(() => import("./pages/Layouts/userLayout"));

function App() {
  return (
    <>
      <Routes>
        <Route path="/*" element={<UserLayout />}></Route>
        <Route path="admin/*" element={<AdminLayout />}></Route>
      </Routes>
    </>
  );
}

export default App;
