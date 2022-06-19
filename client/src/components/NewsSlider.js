import { Swiper, SwiperSlide } from "swiper/react";
// Import Swiper styles
import "swiper/css";
import "swiper/css/pagination";
import "swiper/css/navigation";

// import required modules
import { Pagination, Navigation, Autoplay } from "swiper";
import data from "../data/data.json";

const NewsSlider = () => {
  return (
    <>
      <div>
        <Swiper
          autoplay={{
            delay: 2000,
            disableOnInteraction: false,
          }}
          slidesPerView={3}
          spaceBetween={0}
          style={{ width: "100%" }}
         
          modules={[Pagination, Autoplay]}
          className="mySwiper"
        >
          {data.news.map((item, index) => {
            return (
              <SwiperSlide key={index} className="cursor-pointer w-full">
                <div className="swiper-slide">
                  <img src={item.img} alt="" />
                  <div className="slider-bg absolute bottom-0 right-0 left-0 h-[65px] bg-white opacity-[0.7] "></div>
                  <div className="absolute bottom-0 right-0 left-0 h-[65px] p-1 text-center">
                    <h3 className="text-[12px] font-bold pb-1 text-white">
                      {item.title}
                    </h3>
                    <p className="text-[10px] md:text-xs italic text-white text-center">
                      {item.title}
                    </p>
                  </div>
                </div>
              </SwiperSlide>
            );
          })}
        </Swiper>
      </div>
    </>
  );
};

export default NewsSlider;
