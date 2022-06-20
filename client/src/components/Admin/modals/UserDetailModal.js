import { useEffect, useState } from "react";

function UserDetailModal(props) {
  const { open, data, modal } = props;

  const [user, setUser] = useState([]);

  const [messages, setMessage] = useState("");

  useEffect(() => {
    setUser({
      id: data.id,
      fullName: data.fullName,
      userName: data.userName,
      role: data.role,
      password: "1234567",
    });
  }, [data]);

  const handleSubmit = (e) => {
    e.preventDefault();


    fetch("https://localhost:7001/api/users", {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(user),
    })
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        if (data.success) {
          modal(false);
        } else {
          for (var key in data.errors) {
            setMessage(data.errors[key][0]);
          }
        }
      })
      .catch((err) => console.log(err));
  };

  return (
    <>
      <div
        className={`${
          open === false && "hidden "
        } absolute top-0 left-0 right-0 bottom-0 bg-black opacity-25`}
      ></div>
      <div
        id="defaultModal"
        tabIndex="-1"
        aria-hidden="true"
        className={`${
          open === false && "hidden"
        } flex items-center justify-center overflow-y-auto overflow-x-hidden fixed top-0 right-0 left-0 z-50 w-full md:inset-0 h-modal md:h-full`}
      >
        <form onSubmit={handleSubmit}>
          <div className="relative p-4 w-full max-w-2xl h-full md:h-auto">
            <div className="relative bg-white rounded-lg shadow dark:bg-gray-700">
              <div className="flex justify-between items-start p-4 rounded-t border-b dark:border-gray-600">
                <h3 className="text-xl font-semibold text-gray-900 dark:text-white">
                  {user.fullName || "New User"}{" "}
                  <span className="text-sm font-normal">
                    ({user.role || ""})
                  </span>
                  <p className="w-full text-red-500 text-xs italic">
                    {messages}
                  </p>
                </h3>

                <button
                  onClick={() => {
                    modal(false);
                  }}
                  type="button"
                  className="text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm p-1.5 ml-auto inline-flex items-center dark:hover:bg-gray-600 dark:hover:text-white"
                  data-modal-toggle="defaultModal"
                >
                  <svg
                    className="w-5 h-5"
                    fill="currentColor"
                    viewBox="0 0 20 20"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      fillRule="evenodd"
                      d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                      clipRule="evenodd"
                    ></path>
                  </svg>
                </button>
              </div>
              <div className="px-6 pb-3 space-y-6  md:max-h-[500px] max-h-96 overflow-auto">
                <div className="w-full">
                  <div className="flex flex-wrap -mx-3 mb-6">
                    <div className="w-full px-3 mb-6 md:mb-0">
                      <label
                        className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
                        htmlFor="grid-first-name"
                      >
                        First Name
                      </label>
                      <input
                        className="appearance-none block w-full bg-gray-200 text-gray-700 border border-red-500 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white"
                        id="grid-first-name"
                        type="text"
                        placeholder="First Name"
                        value={user.fullName}
                        onChange={(e) =>
                          setUser({ ...user, fullName: e.target.value })
                        }
                      />
                    </div>
                    <div className="w-full px-3 mb-6 md:mb-0">
                      <label
                        className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
                        htmlFor="grid-first-name"
                      >
                        User Name
                      </label>
                      <input
                        className="appearance-none block w-full bg-gray-200 text-gray-700 border border-red-500 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white"
                        id="grid-user-name"
                        type="text"
                        placeholder="User Name"
                        value={user.userName}
                        onChange={(e) =>
                          setUser({ ...user, userName: e.target.value })
                        }
                      />
                    </div>
                  </div>
                </div>
              </div>

              <div className="flex justify-end items-center p-6 space-x-2 rounded-b border-t border-gray-200 dark:border-gray-600">
                <button
                  data-modal-toggle="defaultModal"
                  type="submit"
                  className="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800"
                >
                  Save
                </button>
                <button
                  onClick={() => {
                    modal(false);
                  }}
                  data-modal-toggle="defaultModal"
                  type="button"
                  className="text-gray-500 bg-white hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10 dark:bg-gray-700 dark:text-gray-300 dark:border-gray-500 dark:hover:text-white dark:hover:bg-gray-600 dark:focus:ring-gray-600"
                >
                  Cancel
                </button>
              </div>
            </div>
          </div>
        </form>
      </div>
    </>
  );
}

export default UserDetailModal;
