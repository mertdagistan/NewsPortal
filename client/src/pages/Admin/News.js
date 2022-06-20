import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
function News() {
  let navigate = useNavigate();

  const [news, setNews] = useState([]);

  useEffect(() => {
    GetNews();
  }, []);

  function GetNews() {
    fetch("https://localhost:7001/api/news", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((res) => res.json())
      .then((data) => {
        setNews(data.result);
      })
      .catch((err) => console.log(err));
  }

  function NewsDetail(id) {
    navigate(`/admin/news/${id}`);
  }
  return (
    <>
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
                      Title
                    </th>
                    <th
                      scope="col"
                      className="text-sm font-bold text-gray-900 px-6 py-4 text-left"
                    >
                      Author
                    </th>
                  </tr>
                </thead>
                <tbody>
                  {news &&
                    news.map((n, index) => {
                      return (
                        <tr
                          onClick={() => NewsDetail(n.id)}
                          className="border-b cursor-pointer hover:bg-gray-100 last:border-0"
                          key={index}
                        >
                          <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                            {index + 1}
                          </td>
                          <td className=" text-gray-900 font-light px-6 py-4 whitespace-nowrap">
                            <span className="text-sm font-bold">{n.title}</span>
                            <p className="text-xs">{n.description}</p>
                          </td>
                          <td className="text-sm text-gray-900 font-light px-6 py-4 whitespace-nowrap">
                            {n.author}
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

export default News;
