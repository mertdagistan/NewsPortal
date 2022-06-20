import { useEffect, useRef, useState } from "react";
import { useParams } from "react-router-dom";
import { Editor } from "@tinymce/tinymce-react";
import { useNavigate } from "react-router-dom";

function NewsDetail() {
  let navigate = useNavigate();
  let params = useParams();
  const editorRef = useRef(null);

  const [news, setNews] = useState([]);
  useEffect(() => {
    if (params.id > 0) {
      GetNews(params.id);
    }
  }, []);

  const GetNews = (id) => {
    fetch(`https://localhost:7001/api/news/${id}`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        setNews(data.entity);
      })
      .catch((err) => console.log(err));
  };
  const handleSubmit = (e) => {
    e.preventDefault();

    if (news.id > 0) UpdateNews();
    else CreateNews();
  };

  const CreateNews = () => {
    fetch(`https://localhost:7001/api/news/`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(news),
    })
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
      })
      .catch((err) => console.log(err));
  };

  const UpdateNews = () => {
    fetch(`https://localhost:7001/api/news/`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(news),
    })
      .then((res) => res.json())
      .then((data) => {
        if (data.success) navigate(`/admin/news/${data.entity.id}`);
      })
      .catch((err) => console.log(err));
  };

  const DeleteNews = () => {
    fetch(`https://localhost:7001/api/news/${news.id}`, {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((res) => res.json())
      .then((data) => {
        if (data.success) navigate(`/admin/news`);
      })
      .catch((err) => console.log(err));
  };

  return (
    <>
      <form onSubmit={handleSubmit}>
        <div className="relative w-full h-full ">
          <div className="relative bg-white rounded-lg shadow-xl ">
            <div className="flex justify-between p-4 shadow-md">
              <div className="flex items-center">
                <button
                  type="button"
                  className="bg-indigo-500 hover:bg-indigo-700 text-white font-bold py-1 px-8 rounded mr-5"
                  onClick={() => navigate("/admin/news")}
                >
                  Geri
                </button>
                <h2>
                  {news.id > 0
                    ? `${news.title.substring(0, 20)}`
                    : "News Detail"}
                </h2>
              </div>
              <div className="flex">
                <button
                  className="bg-green-500 hover:bg-green-700 text-white font-bold py-1 px-8 rounded mr-5"
                  type="submit"
                >
                  Kaydet
                </button>
                {news.id > 0 && (
                  <button
                    className="bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-8 rounded"
                    type="button"
                    onClick={DeleteNews}
                  >
                    Sil
                  </button>
                )}
              </div>
            </div>
            <div className="px-6 pb-3 space-y-6   overflow-auto mt-5">
              <div className="w-full">
                <div className="flex flex-wrap -mx-3 mb-6">
                  {news.id > 0 && (
                    <div className="w-full text-right px-3 mb-3">
                      {`Author: ${news.author}`}
                    </div>
                  )}
                  <div className="w-full px-3 mb-6 md:mb-0">
                    <label
                      className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
                      htmlFor="grid-first-name"
                    >
                      Title
                    </label>
                    <input
                      className="appearance-none block w-full bg-gray-200 text-gray-700 border  rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white"
                      id="grid-first-name"
                      type="text"
                      placeholder="First Name"
                      value={news.title}
                      onChange={(e) =>
                        setNews({ ...news, title: e.target.value })
                      }
                    />
                  </div>
                  <div className="w-full px-3 mb-6 md:mb-0">
                    <label
                      className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
                      htmlFor="grid-first-name"
                    >
                      Description
                    </label>
                    <input
                      className="appearance-none block w-full bg-gray-200 text-gray-700 border  rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white"
                      id="grid-user-name"
                      type="text"
                      placeholder="Description"
                      value={news.description}
                      onChange={(e) =>
                        setNews({ ...news, description: e.target.value })
                      }
                    />
                  </div>
                  <div className="w-full px-3 mb-6 md:mb-0">
                    <label
                      className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
                      htmlFor="img"
                    >
                      Description
                    </label>
                    <input
                      className="appearance-none block w-full bg-gray-200 text-gray-700 border  rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white"
                      id="img"
                      type="file"
                      placeholder="Description"
                    />
                  </div>
                  <div className="w-full px-3 mb-6 md:mb-0">
                    <label
                      className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
                      htmlFor="grid-first-name"
                    >
                      Content
                    </label>
                    <Editor
                      apiKey="p2fmddulancwnpy8u5idvxcxcqq7mw94i368x3as2di0jr01"
                      value={news.content}
                      onInit={(evt, editor) => (editorRef.current = editor)}
                      onEditorChange={(newText) =>
                        setNews({ ...news, content: newText })
                      }
                      init={{
                        height: 500,
                        menubar: true,
                        plugins: [
                          "advlist autolink lists link image charmap print preview anchor",
                          "searchreplace visualblocks code fullscreen",
                          "insertdatetime media table paste code help wordcount",
                        ],
                        toolbar:
                          "undo redo | formatselect | " +
                          "bold italic backcolor | alignleft aligncenter " +
                          "alignright alignjustify | bullist numlist outdent indent | " +
                          "removeformat | help",
                        content_style:
                          "body { font-family:Helvetica,Arial,sans-serif; font-size:14px }",
                      }}
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </form>
    </>
  );
}

export default NewsDetail;
