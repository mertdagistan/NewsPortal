import { useNavigate } from "react-router-dom";
import data from "../data/data.json";

const NewsList = () => {
  let navigate = useNavigate();

  function handleClick(id) {
    navigate(`/${id}`);
  }
  return (
    <>
      <div className="flex flex-col lg:flex-row gap-5 my-5">
        {data.news.map((n, index) => {
          return (
            <div
              className="w-full rounded overflow-hidden shadow-lg hover:shadow-2xl hover:cursor-pointer hover:scale-105"
              key={index}
              onClick={() => handleClick(n.id)}
            >
              <img
                className="w-full h-[200px]"
                src={n.img}
                alt="Sunset in the mountains"
              />
              <div className="px-6 py-4 ">
                <div className="font-bold text-base mb-2 h-[50px] truncate-line line-2">
                  {n.title}
                </div>
                <p className="text-gray-700 text-base h-[100px] truncate-line line-4">
                  {n.description}
                </p>
              </div>
              <div className="px-6 pt-4 pb-2">
                <span className="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2">
                  #photography
                </span>
                <span className="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2">
                  #travel
                </span>
                <span className="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2">
                  #winter
                </span>
              </div>
            </div>
          );
        })}
      </div>
    </>
  );
};

export default NewsList;
