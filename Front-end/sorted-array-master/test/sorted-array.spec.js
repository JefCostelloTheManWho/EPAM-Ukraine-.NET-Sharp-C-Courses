const sortedByRating = require('../src/sorted-array').sortedByRating;
const sortedByPrice = require('../src/sorted-array').sortedByPrice;

const expectedResult1 = [
  {
    ratingReviews: '1355 отзывов',
    price: '4 999 грн',
    name: 'Samsung Galaxy J7 J700H/DS Black + карта памяти 16гб + чехол + защитное стекло!'
  },
  {
    ratingReviews: '1106 отзывов',
    price: '3 999 грн',
    name: 'Samsung Galaxy J5 J500H/DS Black + чехол + защитное стекло!'
  },
  {
    ratingReviews: '709 отзывов',
    price: '2 799 грн',
    name: 'Samsung Galaxy J1 2016 SM-J120H Black + защитное стекло + чехол!'
  },
  {
    ratingReviews: '527 отзывов',
    price: '3 999 грн',
    name: 'Huawei Y6 Pro Gold + чехол + защитное стекло!'
  },
  {
    ratingReviews: '488 отзывов',
    price: '6 199 грн',
    name: 'Samsung Galaxy J7 (2016) J710F/DS Gold + защитное стекло + чехол!'
  },
  {
    ratingReviews: '426 отзывов',
    price: '5 199 грн',
    name: 'Samsung Galaxy J5 (2016) J510H/DS Black + защитное стекло + чехол!'
  },
  {
    ratingReviews: '403 отзыва',
    price: '4 349 грн',
    name: 'Xiaomi Redmi Note 4X 3/32GB Black'
  },
  {
    ratingReviews: '380 отзывов',
    price: '2 199 грн',
    name: 'Huawei Y3 II Tiffany (White-Blue) + чехол + защитное стекло!'
  },
  {
    ratingReviews: '376 отзывов',
    price: '3 899 грн',
    name: 'Meizu M3 Note 32GB Grey (Международная версия)'
  },
  {
    ratingReviews: '352 отзыва',
    price: { oldUan: '9 799 грн', newUan: '7 999 грн' },
    name: 'Apple iPhone 5s 16GB Space Gray'
  },
  {
    ratingReviews: '347 отзывов',
    price: '4 299 грн',
    name: 'Xiaomi Redmi 4X 3/32GB Black (Международная версия)'
  },
  {
    ratingReviews: '264 отзыва',
    price: { oldUan: '4 333 грн', newUan: '3 799 грн' },
    name: 'Motorola MOTO G4 (XT1622) Black'
  },
  {
    ratingReviews: '198 отзывов',
    price: { oldUan: '3 495 грн', newUan: '2 995 грн' },
    name: 'Lenovo K5 (A6020a40) Silver'
  },
  {
    ratingReviews: '177 отзывов',
    price: '6 499 грн',
    name: 'Huawei P8 Lite 2017 White + УМБ Huawei AP08Q + защитное стекло + чехол!'
  },
  {
    ratingReviews: '156 отзывов',
    price: '2 599 грн',
    name: 'Nous NS 5006 Gold'
  },
  {
    ratingReviews: '119 отзывов',
    price: '11 999 грн',
    name: 'Samsung Galaxy A5 2017 Duos SM-A520 Black + карта памяти 128гб!'
  },
  {
    ratingReviews: '111 отзывов',
    price: { oldUan: '9 999 грн', newUan: '7 999 грн' },
    name: 'Sony Xperia X Dual (F5122) White'
  },
  {
    ratingReviews: '93 отзыва',
    price: '18 999 грн',
    name: 'Apple iPhone 7 32GB Black'
  },
  {
    ratingReviews: '86 отзывов',
    price: { oldUan: '24 999 грн', newUan: '22 999 грн' },
    name: 'Samsung Galaxy S8 64GB Midnight Black + карта памяти 64гб + оригинальный чехол!'
  },
  {
    ratingReviews: '71 отзыв',
    price: { oldUan: '2 399 грн', newUan: '1 999 грн' },
    name: 'LG K5 X220ds Gold'
  },
  {
    ratingReviews: '70 отзывов',
    price: { oldUan: '7 399 грн', newUan: '5 999 грн' },
    name: 'Asus ZenFone 2 32GB (ZE551ML) Black'
  },
  {
    ratingReviews: '66 отзывов',
    price: '16 499 грн',
    name: 'Apple iPhone 6s 32GB Gold'
  },
  {
    ratingReviews: '59 отзывов',
    price: '6 000 грн',
    name: 'Nokia 5 Dual Sim Tempered Blue'
  },
  {
    ratingReviews: '45 отзывов',
    price: '4 299 грн',
    name: 'Nokia 3 Dual Sim Silver White + сертификаты 500 грн!'
  },
  {
    ratingReviews: '40 отзывов',
    price: '2 222 грн',
    name: 'Lenovo Vibe C (A2020) Black + УМБ PowerPlant 5200 mAh в подарок!'
  },
  {
    ratingReviews: '40 отзывов',
    price: '19 689 грн',
    name: 'LG G6 Mystic White'
  },
  {
    ratingReviews: '39 отзывов',
    price: '2 995 грн',
    name: 'Lenovo C2 Power (K10a40) Black'
  },
  {
    ratingReviews: '33 отзыва',
    price: '16 999 грн',
    name: 'Huawei P10 4/32GB Black + сертификат 2500грн + чехол Huawei Smart View Cover!'
  },
  {
    ratingReviews: '24 отзыва',
    price: '5 995 грн',
    name: 'Motorola MOTO G5 (XT1676) Grey'
  },
  {
    ratingReviews: '18 отзывов',
    price: { oldUan: '5 999 грн', newUan: '4 999 грн' },
    name: 'Sony Xperia L1 Dual Black'
  },
  {
    ratingReviews: '14 отзывов',
    price: '11 499 грн',
    name: 'Apple iPhone 6 32GB Space Gray'
  },
  {
    ratingReviews: '7 отзывов',
    price: { oldUan: '10 999 грн', newUan: '9 999 грн' },
    name: 'HTC One X10 Dual Sim Silver'
  }
];

const expectedResult2 = [
      {
        ratingReviews: '86 отзывов',
        price: { oldUan: '24 999 грн', newUan: '22 999 грн' },
        name: 'Samsung Galaxy S8 64GB Midnight Black + карта памяти 64гб + оригинальный чехол!'
      },
      {
        ratingReviews: '40 отзывов',
        price: '19 689 грн',
        name: 'LG G6 Mystic White'
      },
      {
        ratingReviews: '93 отзыва',
        price: '18 999 грн',
        name: 'Apple iPhone 7 32GB Black'
      },
      {
        ratingReviews: '33 отзыва',
        price: '16 999 грн',
        name: 'Huawei P10 4/32GB Black + сертификат 2500грн + чехол Huawei Smart View Cover!'
      },
      {
        ratingReviews: '66 отзывов',
        price: '16 499 грн',
        name: 'Apple iPhone 6s 32GB Gold'
      },
      {
        ratingReviews: '119 отзывов',
        price: '11 999 грн',
        name: 'Samsung Galaxy A5 2017 Duos SM-A520 Black + карта памяти 128гб!'
      },
      {
        ratingReviews: '14 отзывов',
        price: '11 499 грн',
        name: 'Apple iPhone 6 32GB Space Gray'
      },
      {
        ratingReviews: '7 отзывов',
        price: { oldUan: '10 999 грн', newUan: '9 999 грн' },
        name: 'HTC One X10 Dual Sim Silver'
      },
      {
        ratingReviews: '352 отзыва',
        price: { oldUan: '9 799 грн', newUan: '7 999 грн' },
        name: 'Apple iPhone 5s 16GB Space Gray'
      },
      {
        ratingReviews: '111 отзывов',
        price: { oldUan: '9 999 грн', newUan: '7 999 грн' },
        name: 'Sony Xperia X Dual (F5122) White'
      },
      {
        ratingReviews: '177 отзывов',
        price: '6 499 грн',
        name: 'Huawei P8 Lite 2017 White + УМБ Huawei AP08Q + защитное стекло + чехол!'
      },
      {
        ratingReviews: '488 отзывов',
        price: '6 199 грн',
        name: 'Samsung Galaxy J7 (2016) J710F/DS Gold + защитное стекло + чехол!'
      },
      {
        ratingReviews: '59 отзывов',
        price: '6 000 грн',
        name: 'Nokia 5 Dual Sim Tempered Blue'
      },
      {
        ratingReviews: '70 отзывов',
        price: { oldUan: '7 399 грн', newUan: '5 999 грн' },
        name: 'Asus ZenFone 2 32GB (ZE551ML) Black'
      },
      {
        ratingReviews: '24 отзыва',
        price: '5 995 грн',
        name: 'Motorola MOTO G5 (XT1676) Grey'
      },
      {
        ratingReviews: '426 отзывов',
        price: '5 199 грн',
        name: 'Samsung Galaxy J5 (2016) J510H/DS Black + защитное стекло + чехол!'
      },
      {
        ratingReviews: '1355 отзывов',
        price: '4 999 грн',
        name: 'Samsung Galaxy J7 J700H/DS Black + карта памяти 16гб + чехол + защитное стекло!'
      },
      {
        ratingReviews: '18 отзывов',
        price: { oldUan: '5 999 грн', newUan: '4 999 грн' },
        name: 'Sony Xperia L1 Dual Black'
      },
      {
        ratingReviews: '403 отзыва',
        price: '4 349 грн',
        name: 'Xiaomi Redmi Note 4X 3/32GB Black'
      },
      {
        ratingReviews: '347 отзывов',
        price: '4 299 грн',
        name: 'Xiaomi Redmi 4X 3/32GB Black (Международная версия)'
      },
      {
        ratingReviews: '45 отзывов',
        price: '4 299 грн',
        name: 'Nokia 3 Dual Sim Silver White + сертификаты 500 грн!'
      },
      {
        ratingReviews: '1106 отзывов',
        price: '3 999 грн',
        name: 'Samsung Galaxy J5 J500H/DS Black + чехол + защитное стекло!'
      },
      {
        ratingReviews: '527 отзывов',
        price: '3 999 грн',
        name: 'Huawei Y6 Pro Gold + чехол + защитное стекло!'
      },
      {
        ratingReviews: '376 отзывов',
        price: '3 899 грн',
        name: 'Meizu M3 Note 32GB Grey (Международная версия)'
      },
      {
        ratingReviews: '264 отзыва',
        price: { oldUan: '4 333 грн', newUan: '3 799 грн' },
        name: 'Motorola MOTO G4 (XT1622) Black'
      },
      {
        ratingReviews: '198 отзывов',
        price: { oldUan: '3 495 грн', newUan: '2 995 грн' },
        name: 'Lenovo K5 (A6020a40) Silver'
      },
      {
        ratingReviews: '39 отзывов',
        price: '2 995 грн',
        name: 'Lenovo C2 Power (K10a40) Black'
      },
      {
        ratingReviews: '709 отзывов',
        price: '2 799 грн',
        name: 'Samsung Galaxy J1 2016 SM-J120H Black + защитное стекло + чехол!'
      },
      {
        ratingReviews: '156 отзывов',
        price: '2 599 грн',
        name: 'Nous NS 5006 Gold'
      },
      {
        ratingReviews: '40 отзывов',
        price: '2 222 грн',
        name: 'Lenovo Vibe C (A2020) Black + УМБ PowerPlant 5200 mAh в подарок!'
      },
      {
        ratingReviews: '380 отзывов',
        price: '2 199 грн',
        name: 'Huawei Y3 II Tiffany (White-Blue) + чехол + защитное стекло!'
      },
      {
        ratingReviews: '71 отзыв',
        price: { oldUan: '2 399 грн', newUan: '1 999 грн' },
        name: 'LG K5 X220ds Gold'
      }
    ];

describe('sortedByRating', () => {
    it('Should return sorted array according to rating', () => {
      expect(sortedByRating()).to.deep.equal(expectedResult1)
  });
})


describe('sortedByPrice', () => {
    it('Should return sorted array according to price', () => {
      expect(sortedByPrice()).to.deep.equal(expectedResult2)
  });
})
