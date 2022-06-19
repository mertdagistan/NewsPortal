import NewsList from "../../components/NewsList";
import NewsSlider from "../../components/NewsSlider";

function Home() {
  return (
    <>
      <div className="flex mt-5">
        <div className="w-full">
          <NewsSlider />
        </div>

        {/* <div className="w-full lg:w-1/4">
            <NewsBox />
          </div> */}
      </div>
      <div className="container">
        <div className="section_title">
          <h2 className="text-4xl font-bold mr-10">Recent News</h2>
        </div>
        <NewsList />
      </div>
    </>
  );
}
export default Home;
