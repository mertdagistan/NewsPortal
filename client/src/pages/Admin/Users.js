import { useEffect, useState } from "react";
import UserDetailModal from "../../components/Admin/modals/UserDetailModal";

function Users() {

  const [users, setUsers] = useState([]);
  const [modal, setUserDetailModal] = useState(false);
  const [selectedData, setData] = useState([]);

  useEffect(() => {
    GetUsers();
  }, [modal]);

  function GetUsers() {
    fetch("https://localhost:7001/api/users", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((res) => res.json())
      .then((data) => {
        setUsers(data.result);
      })
      .catch((err) => console.log(err));
  }
  return (
    <>
      <UserDetailModal
        modal={setUserDetailModal}
        open={modal}
        data={selectedData}
      />
      <span className="text-2xl">Users</span>
      <div className="flex flex-col shadow-lg">
        <div className="overflow-x-auto sm:-mx-6 lg:-mx-8">
          <div className="py-2 inline-block min-w-full sm:px-6 lg:px-8">
            <div className="overflow-hidden">
              <table className="min-w-full">
                <thead className="border-b">
                  <tr>
                    <th
                      scope="col"
                      className="text-sm font-bold text-gray-900 px-6 py-4 text-left"
                    >
                      #
                    </th>
                    <th
                      scope="col"
                      className="text-sm font-bold text-gray-900 px-6 py-4 text-left"
                    >
                      Full Name
                    </th>
                    <th
                      scope="col"
                      className="text-sm font-bold text-gray-900 px-6 py-4 text-left"
                    >
                      User Name
                    </th>
                    <th
                      scope="col"
                      className="text-sm font-bold text-gray-900 px-6 py-4 text-left"
                    >
                      Role
                    </th>
                  </tr>
                </thead>
                <tbody>
                  {users &&
                    users.map((user, index) => {
                      return (
                        <tr
                          className="border-b cursor-pointer hover:bg-gray-100 last:border-0"
                          key={index}
                          onClick={() => {
                            setData(user);
                            setUserDetailModal(true);
                          }}
                        >
                          <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                            {index + 1}
                          </td>
                          <td className="text-sm text-gray-900 font-light px-6 py-4 whitespace-nowrap">
                            {user.fullName}
                          </td>
                          <td className="text-sm text-gray-900 font-light px-6 py-4 whitespace-nowrap">
                            {user.userName}
                          </td>
                          <td className="text-sm text-gray-900 font-light px-6 py-4 whitespace-nowrap">
                            {user.role}
                          </td>
                        </tr>
                      );
                    })}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default Users;
