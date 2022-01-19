using System;
using System.Collections.Generic;
using PolynomialObject;
using PolynomialObject.Exceptions;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PolynomialTest
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.00001)]
    public class PolynomialTest
    {
        private Polynomial _polynomial;
        private PolynomialComparer _polynomialComparer = new PolynomialComparer();
        private const double Precision = 0.00001;

        [SetUp]
        public void Setup()
        {
            _polynomial = new Polynomial(new PolynomialMember[]{
                new PolynomialMember(5, 8),
                new PolynomialMember(2, -3.3),
                new PolynomialMember(0, 1.3),
                new PolynomialMember(-2.4, 2),
                new PolynomialMember(-9.4, -1.8)
            });
        }

        private void AssertIsAsExpected<T>(IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer)
        {
            Assert.True(expected.SequenceEqual(actual, comparer), "Result is not as expected");
        }

        #region low

        #region Data for Low Level
        // Data for operator + and method Add
        private static IEnumerable<TestCaseData> AddPolynomialTestCases
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new PolynomialMember(8, -3.2)), new Polynomial(new PolynomialMember(-4.9, -7.6)),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(8, -3.2),
                        new PolynomialMember(-4.9, -7.6)
                }));
                yield return new TestCaseData(new Polynomial(new PolynomialMember(8, -3.2)), new Polynomial(new PolynomialMember(-5.2, 9)),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(8, -3.2),
                        new PolynomialMember(-5.2, 9)
                }));
                yield return new TestCaseData(new Polynomial(new PolynomialMember(8, -3.2)), new Polynomial(new PolynomialMember(2, 0.5)), new Polynomial(
                    new PolynomialMember[] {
                        new PolynomialMember(2, 0.5),
                        new PolynomialMember(8, -3.2)
                }));
                yield return new TestCaseData(new Polynomial(new PolynomialMember(1, 2)), new Polynomial(new PolynomialMember(1, -2)), new Polynomial());
                yield return new TestCaseData(
                    new Polynomial(new PolynomialMember(0, 10)),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(0, 10.2),
                        new PolynomialMember(2, -1)
                    }),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(0, 20.2),
                        new PolynomialMember(2, -1)
                    }));
                yield return new TestCaseData(
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(1, -5),
                        new PolynomialMember(0, -2)
                    }),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(0, 2),
                        new PolynomialMember(1, -5)
                    }),
                    new Polynomial(new PolynomialMember(1, -10)));

                yield return new TestCaseData(new Polynomial(new PolynomialMember(0, 0)), new Polynomial(new PolynomialMember(0.0, 0.0)), new Polynomial());
                yield return new TestCaseData(new Polynomial(new PolynomialMember(1, 2)), new Polynomial(new PolynomialMember(5, 0)), new Polynomial(new PolynomialMember(1, 2)));
            }
        }
        // Data for operator - and method Subtraction
        private static IEnumerable<TestCaseData> SubtractionPolynomialTestCases
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new PolynomialMember(1, 0.5)), new Polynomial(new PolynomialMember(2, 5)), new Polynomial(
                    new PolynomialMember[] {
                        new PolynomialMember(2, -5),
                        new PolynomialMember(1, 0.5)
                }));
                yield return new TestCaseData(new Polynomial(), new Polynomial(new PolynomialMember(5, -6)), new Polynomial(new PolynomialMember(5, 6)));
                yield return new TestCaseData(
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(1, -5),
                        new PolynomialMember(0, -2)
                    }),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(0, 2),
                        new PolynomialMember(2, 5.6),
                        new PolynomialMember(1, -5)
                    }),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(2, -5.6),
                        new PolynomialMember(0, -4)
                    }));
                yield return new TestCaseData(
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(Math.Sqrt(3), -5),
                        new PolynomialMember(0, 2)
                    }),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(Math.Sqrt(3), 2),
                        new PolynomialMember(0, -5)
                    }),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(Math.Sqrt(3), -7),
                        new PolynomialMember(0, 7)
                    }));
                yield return new TestCaseData(new Polynomial(new PolynomialMember(1, 2)), new Polynomial(new PolynomialMember(0, 0)), new Polynomial(new PolynomialMember(1, 2)));
                yield return new TestCaseData(new Polynomial(new PolynomialMember(0, 0)), new Polynomial(new PolynomialMember(1, 0.0)), new Polynomial());
            }
        }
        // Data for operator * and method Multiply
        private static IEnumerable<TestCaseData> MultiplyPolynomialTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(1, 0.5),
                        new PolynomialMember(2, 5)
                    }),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(0, 0),
                        new PolynomialMember(3, -6)
                    }),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(4, -3),
                        new PolynomialMember(5, -30)
                    }));
                yield return new TestCaseData(
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(1, 1),
                        new PolynomialMember(0, 1)
                    }),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(1, 1),
                        new PolynomialMember(0, 2)
                    }),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(2, 1),
                        new PolynomialMember(1, 3),
                        new PolynomialMember(0, 2)
                    }));
                yield return new TestCaseData(
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(2, -1),
                        new PolynomialMember(1, -1)
                    }),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(1, -1),
                        new PolynomialMember(0, 5)
                    }),
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(3, 1),
                        new PolynomialMember(2, -4),
                        new PolynomialMember(1, -5)
                    }));

                yield return new TestCaseData(new Polynomial(), new Polynomial(new PolynomialMember(1, 0.5)), new Polynomial());
                yield return new TestCaseData(new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(1, -0.5),
                        new PolynomialMember(2, 5)
                    }), new Polynomial(new PolynomialMember(0, 0)), new Polynomial());
                yield return new TestCaseData(new Polynomial(new PolynomialMember(0, 0)), new Polynomial(new PolynomialMember(0.0, 0.0)), new Polynomial());
            }
        }
        #endregion

        #region Basic method (AddMember, RemoveMember, ContainsMember, Indexer)
        [TestCase(10, 10)]
        [TestCase(-4, 0.5)]
        [TestCase(1.00001, -6.7)]
        public void AddMember_NotNullPolynomialMember_AddedElement(double degree, double coefficient)
        {
            // arrange
            int expectedLength = _polynomial.Count + 1;
            var newEl = new PolynomialMember(degree, coefficient);
            // act
            _polynomial.AddMember(newEl);
            // assert
            Assert.AreEqual(expectedLength, _polynomial.Count);
            var isAdded = Array.Find(_polynomial.ToArray(), x => Math.Abs(x.Degree - degree) < Precision);
            Assert.IsTrue(Math.Abs(isAdded.Degree - newEl.Degree) < Precision && Math.Abs(isAdded.Coefficient - newEl.Coefficient) < Precision);
        }

        [TestCase(5, 1, ExpectedResult = true)]
        [TestCase(-2.4, 1, ExpectedResult = true)]
        [TestCase(2, 1, ExpectedResult = true)]
        [TestCase(-9.4, 1, ExpectedResult = true)]
        [TestCase(0.0, 1, ExpectedResult = true)]
        [TestCase(-5, 0, ExpectedResult = false)]
        public bool RemoveMember_PolynomialMemberDegree_BooleanResultOfRemoving(double degree, int elLength)
        {
            // arrange
            int expectedLength = _polynomial.Count - elLength;

            // act
            bool actualResult = _polynomial.RemoveMember(degree);

            // assert
            Assert.AreEqual(expectedLength, _polynomial.Count);
            var isAdded = Array.Find(_polynomial.ToArray(), x => Math.Abs(x.Degree - degree) < Precision);
            Assert.IsNull(isAdded);
            return actualResult;
        }

        [Test]
        public void RemoveMember_PolynomialMemberDegree_EmptyPolynomial()
        {
            // arrange
            int degree = 3;
            Polynomial pol = new Polynomial(new PolynomialMember(degree, 5));
            int expectedLength = 0;

            // act
            bool actualResult = pol.RemoveMember(degree);

            // assert
            Assert.IsTrue(actualResult);
            Assert.AreEqual(expectedLength, pol.Count);
        }

        [TestCase(5, ExpectedResult = true)]
        [TestCase(-2.4, ExpectedResult = true)]
        [TestCase(1.000001, ExpectedResult = false)]
        [TestCase(0.0, ExpectedResult = true)]
        [TestCase(-5, ExpectedResult = false)]
        public bool ContainsMember_PolynomialMemberDegree_BooleanResult(double degree)
        {
            return _polynomial.ContainsMember(degree);
        }

        [TestCase(5, 8)]
        [TestCase(-2.4, 2)]
        public void Indexer_ExistDegreeAndGetCoefficient_MemberCoefficient(double degree, double expectedResult)
        {
            double actualResult = _polynomial[degree];
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(5, 1.3)]
        [TestCase(-2.4, -5.6)]
        [TestCase(2, 2)]
        [TestCase(-9.4, -6.3)]
        public void Indexer_ExistDegreeAndSetNewCoefficient_ChangeCoefficient(double degree, double newCoef)
        {
            _polynomial[degree] = newCoef;

            double actualResult = _polynomial[degree];
            Assert.AreEqual(newCoef, actualResult);
        }

        [TestCase(5, 0)]
        [TestCase(-9.4, 0)]
        [TestCase(0, 0)]
        public void Indexer_ExistDegreeAndSetZeroCoefficient_RemoveMember(double degree, double coefficient)
        {
            // arrange
            int expectedLength = _polynomial.Count - 1;
            // act
            _polynomial[degree] = coefficient;
            // assert
            Assert.AreEqual(expectedLength, _polynomial.Count);
            var isRemoved = Array.Find(_polynomial.ToArray(), x => Math.Abs(x.Degree - degree) < Precision);
            Assert.IsNull(isRemoved);
        }

        [TestCase(-1, -0.558)]
        [TestCase(10, -5)]
        public void Indexer_NotExistDegreeAndSetNotZeroCoefficient_AddNewMember(double degree, double coefficient)
        {
            // arrange
            int expectedLength = _polynomial.Count + 1;
            // act
            _polynomial[degree] = coefficient;
            // assert
            Assert.AreEqual(expectedLength, _polynomial.Count);
            var isAdded = Array.Find(_polynomial.ToArray(), x => Math.Abs(x.Degree - degree) < Precision);
            Assert.IsTrue(Math.Abs(isAdded.Degree - degree) < Precision && Math.Abs(isAdded.Coefficient - coefficient) < Precision);
        }

        [TestCase(-10, 0)]
        [TestCase(50, 0)]
        public void Indexer_NotExistDegreeAndSetZeroCoefficient_BasisPolynomial(double degree, double coefficient)
        {
            // arrange
            int expectedLength = _polynomial.Count;
            // act
            _polynomial[degree] = coefficient;
            // assert
            Assert.AreEqual(expectedLength, _polynomial.Count);
            var isNotAdded = Array.Find(_polynomial.ToArray(), x => Math.Abs(x.Degree - degree) < Precision);
            Assert.IsNull(isNotAdded);
        }
        #endregion

        #region operators +, -, * and methods Add, Subtraction, Multiply for Polynomial
        [TestCaseSource("AddPolynomialTestCases")]
        public void AddByOperator_PolynomialPlusPolynomial_NewPolynomial(Polynomial membersA,
            Polynomial membersB, Polynomial expectedResult)
        {
            // act 
            var actualResult = membersA + membersB;
            // assert
            AssertIsAsExpected(expectedResult.ToArray().OrderBy(x => x.Degree), actualResult.ToArray().OrderBy(x => x.Degree), _polynomialComparer);
        }

        [TestCaseSource("AddPolynomialTestCases")]
        public void Add_PolynomialPlusPolynomial_NewPolynomial(Polynomial membersA,
            Polynomial membersB, Polynomial expectedResult)
        {
            // act 
            var actualResult = membersA.Add(membersB);
            // assert
            AssertIsAsExpected(expectedResult.ToArray().OrderBy(x => x.Degree), actualResult.ToArray().OrderBy(x => x.Degree), _polynomialComparer);
        }

        [TestCaseSource("SubtractionPolynomialTestCases")]
        public void SubtractionByOperator_PolynomialMinusPolynomial_NewPolynomial(Polynomial membersA,
            Polynomial membersB, Polynomial expectedResult)
        {
            // act 
            var actualResult = membersA - membersB;
            // assert
            AssertIsAsExpected(expectedResult.ToArray().OrderBy(x => x.Degree), actualResult.ToArray().OrderBy(x => x.Degree), _polynomialComparer);
        }

        [TestCaseSource("SubtractionPolynomialTestCases")]
        public void Subtraction_PolynomialMinusPolynomial_NewPolynomial(Polynomial membersA,
            Polynomial membersB, Polynomial expectedResult)
        {
            // act 
            var actualResult = membersA.Subtraction(membersB);
            // assert
            AssertIsAsExpected(expectedResult.ToArray().OrderBy(x => x.Degree), actualResult.ToArray().OrderBy(x => x.Degree), _polynomialComparer);
        }

        [TestCaseSource("MultiplyPolynomialTestCases")]
        public void MultiplyByOperator_PolynomialMultiplyPolynomial_NewPolynomial(Polynomial membersA,
            Polynomial membersB, Polynomial expectedResult)
        {
            // act 
            var actualResult = membersA * membersB;
            // assert
            AssertIsAsExpected(expectedResult.ToArray().OrderBy(x => x.Degree), actualResult.ToArray().OrderBy(x => x.Degree), _polynomialComparer);
        }

        [TestCaseSource("MultiplyPolynomialTestCases")]
        public void Multiply_PolynomialMultiplyPolynomial_NewPolynomial(Polynomial membersA,
            Polynomial membersB, Polynomial expectedResult)
        {
            // act 
            var actualResult = membersA.Multiply(membersB);
            // assert
            AssertIsAsExpected(expectedResult.ToArray().OrderBy(x => x.Degree), actualResult.ToArray().OrderBy(x => x.Degree), _polynomialComparer);
        }
        #endregion

        #endregion

                // UNCOMMENT TO CHECK ADVANCED PART
        /*#region advanced

        #region Data for Advanced Level
        private static IEnumerable<TestCaseData> AddPolynomialTuplesTestCases
        {
            get
            {
                yield return new TestCaseData(new Polynomial((1, 2)), 2, 0.5, new Polynomial(
                    new PolynomialMember[] {
                        new PolynomialMember(2, 0.5),
                        new PolynomialMember(1, 2)
                }));
                yield return new TestCaseData(new Polynomial((1, 2)), 0, 0, new Polynomial(new PolynomialMember(1, 2)));
                yield return new TestCaseData(new Polynomial(), 2, 5, new Polynomial(new PolynomialMember(2, 5)));
                yield return new TestCaseData(new Polynomial((1, 2)), 2, 0.5, new Polynomial(
                    new PolynomialMember[] {
                        new PolynomialMember(1, 2),
                        new PolynomialMember(2, 0.5)
                }));
                yield return new TestCaseData(new Polynomial((1, 2)), 1, -2, new Polynomial());
            }
        }
        private static IEnumerable<TestCaseData> SubtractionPolynomialTuplesTestCases
        {
            get
            {
                yield return new TestCaseData(new Polynomial(), 2, 5, new Polynomial((2, -5)));
                yield return new TestCaseData(new Polynomial((0, 0)), 0, 0, new Polynomial());
                yield return new TestCaseData(new Polynomial((1, 0.5)), 0, 0, new Polynomial((1, 0.5)));
                yield return new TestCaseData(new Polynomial((1, 0.5)), 2, 5, new Polynomial(
                    new PolynomialMember[] {
                        new PolynomialMember(2, -5),
                        new PolynomialMember(1, 0.5)
                }));
                yield return new TestCaseData(new Polynomial((1, 2)), 1, 2, new Polynomial());
            }
        }
        private static IEnumerable<TestCaseData> MultiplyPolynomialTuplesTestCases
        {
            get
            {
                yield return new TestCaseData(new Polynomial(), 2, 5, new Polynomial());
                yield return new TestCaseData(new Polynomial((0, 0)), 0, 0, new Polynomial());
                yield return new TestCaseData(new Polynomial((1, 0.5)), 0, 0, new Polynomial());
                yield return new TestCaseData(new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(1, -0.5),
                        new PolynomialMember(2, 5)
                    }), 0, 0, new Polynomial());
                yield return new TestCaseData(
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(1, 1),
                        new PolynomialMember(0, 1)
                    }),
                    1, 1,
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(2, 1),
                        new PolynomialMember(1, 1)
                    }));
                yield return new TestCaseData(
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(2, -1),
                        new PolynomialMember(1, -1)
                    }),
                    1, -1,
                    new Polynomial(new PolynomialMember[] {
                        new PolynomialMember(3, 1),
                        new PolynomialMember(2, 1)
                    }));
            }
        }
        #endregion

        #region exceptions for low level
        [TestCase(4, 0)]
        [TestCase(0, 0)]
        public void AddMember_ZeroPolynomialMember_ThrowPolynomialArgumentException(double degree, double coefficient)
        {
            // arrange
            var expectedTypeError = typeof(PolynomialArgumentException);
            // act
            Exception ex = Assert.Catch(() => _polynomial.AddMember(new PolynomialMember(degree, coefficient)));
            // assert
            Assert.AreEqual(expectedTypeError, ex.GetType(),
                message: "AddMember method throw PolynomialArgumentException if coefficient is 0 in PolynomialMember. ");
        }

        [TestCase(5, 0)]
        [TestCase(5, 1)]
        public void AddMember_PolynomialMemberWithContainedDegree_ThrowPolynomialArgumentException(double degree, double coefficient)
        {
            // arrange
            var expectedTypeError = typeof(PolynomialArgumentException);
            // act
            Exception ex = Assert.Catch(() => _polynomial.AddMember(new PolynomialMember(degree, coefficient)));
            // assert
            Assert.AreEqual(expectedTypeError, ex.GetType(),
                message: "AddMember method throw PolynomialArgumentException if there is element with such coefficient. ");
        }

        [Test]
        public void AddMember_NullParam_ThrowArgumentNullException()
        {
            // arrange
            var expectedTypeError = typeof(PolynomialArgumentNullException);
            // act
            Exception ex = Assert.Catch(() => _polynomial.AddMember((PolynomialMember)null));
            // assert
            Assert.AreEqual(expectedTypeError, ex.GetType(),
                message: "AddMember method throw PolynomialArgumentNullException if parameter is null. ");
        }

        [Test]
        public void AddByOperator_PolynomialPlusNullPolynomial_ThrowArgumentNullException()
        {
            // arrange
            var expectedTypeError = typeof(PolynomialArgumentNullException);
            // act 
            Exception ex = Assert.Catch(() => { var res = _polynomial + (Polynomial)null; });
            Exception ex2 = Assert.Catch(() => { var res = (Polynomial)null + _polynomial; });
            // assert
            Assert.AreEqual(expectedTypeError, ex.GetType(),
               message: "Operator '+' throw PolynomialArgumentNullException if one of polynomials is null. ");
            Assert.AreEqual(expectedTypeError, ex2.GetType(),
               message: "Operator '+' throw PolynomialArgumentNullException if one of polynomials is null. ");
        }

        [Test]
        public void Add_PolynomialPlusNullPolynomial_ThrowArgumentNullException()
        {
            // arrange
            var expectedTypeError = typeof(PolynomialArgumentNullException);
            // act 
            Exception ex = Assert.Catch(() => _polynomial.Add((Polynomial)null));
            // assert
            Assert.AreEqual(expectedTypeError, ex.GetType(),
               message: "Add method throw PolynomialArgumentNullException if parametr is null. ");
        }

        [Test]
        public void SubtractionByOperator_PolynomialMinusNullPolynomial_ThrowArgumentNullException()
        {
            // arrange
            var expectedTypeError = typeof(PolynomialArgumentNullException);
            // act 
            Exception ex = Assert.Catch(() => { var res = _polynomial - (Polynomial)null; });
            Exception ex2 = Assert.Catch(() => { var res = (Polynomial)null - _polynomial; });
            // assert
            Assert.AreEqual(expectedTypeError, ex.GetType(),
               message: "Operator '-' throw PolynomialArgumentNullException if one of polynomials is null. ");
            Assert.AreEqual(expectedTypeError, ex.GetType(),
               message: "Operator '-' throw PolynomialArgumentNullException if one of polynomials is null. ");
        }

        [Test]
        public void Subtraction_PolynomialMinusNullPolynomial_ThrowArgumentNullException()
        {
            // arrange
            var expectedTypeError = typeof(PolynomialArgumentNullException);
            // act 
            Exception ex = Assert.Catch(() => _polynomial.Subtraction((Polynomial)null));
            // assert
            Assert.AreEqual(expectedTypeError, ex.GetType(),
               message: "Subtraction method throw PolynomialArgumentNullException if parametr is null. ");
        }

        [Test]
        public void MultiplyByOperator_PolynomialMultiplyNullPolynomial_ThrowArgumentNullException()
        {
            // arrange
            var expectedTypeError = typeof(PolynomialArgumentNullException);
            // act 
            Exception ex = Assert.Catch(() => { var res = _polynomial * (Polynomial)null; });
            Exception ex2 = Assert.Catch(() => { var res = (Polynomial)null * _polynomial; });
            // assert
            Assert.AreEqual(expectedTypeError, ex.GetType(),
               message: "Operator '*' throw PolynomialArgumentNullException if parametr is null. ");
            Assert.AreEqual(expectedTypeError, ex.GetType(),
               message: "Operator '*' throw PolynomialArgumentNullException if one of polynomials is null. ");
        }

        [Test]
        public void Multiply_PolynomialMultiplyNullPolynomial_ThrowArgumentNullException()
        {
            // arrange
            var expectedTypeError = typeof(PolynomialArgumentNullException);
            // act 
            Exception ex = Assert.Catch(() => _polynomial.Multiply((Polynomial)null));
            // assert
            Assert.AreEqual(expectedTypeError, ex.GetType(),
                message: "Multiply method throw PolynomialArgumentNullException if parametr is null. ");
        }
        #endregion

        #region methods for polynomial Tuple 
        [TestCase(10, 10)]
        [TestCase(-4, 0.5)]
        [TestCase(1.00001, -6.7)]
        [TestCase(0.1, -6.7)]
        public void AddMember_NotNullTuple_AddedElement(double degree, double coefficient)
        {
            // arrange
            int expectedLenght = _polynomial.Count + 1;
            // act
            _polynomial.AddMember((degree, coefficient));
            // assert
            Assert.AreEqual(expectedLenght, _polynomial.Count);
        }

        [TestCaseSource("AddPolynomialTuplesTestCases")]
        public void AddByOperator_PolynomialPlusPolynomialTuple_NewPolynomial(Polynomial membersA,
            double degree, double coeff, Polynomial expectedResult)
        {
            // act 
            var actualResult = membersA + (degree, coeff);
            // assert
            AssertIsAsExpected(expectedResult.ToArray().OrderBy(x => x.Degree), actualResult.ToArray().OrderBy(x => x.Degree), _polynomialComparer);
        }

        [TestCaseSource("AddPolynomialTuplesTestCases")]
        public void Add_PolynomialPlusPolynomialTuple_NewPolynomial(Polynomial membersA,
            double degree, double coeff, Polynomial expectedResult)
        {
            // act 
            var actualResult = membersA.Add((degree, coeff));
            // assert
            AssertIsAsExpected(expectedResult.ToArray().OrderBy(x => x.Degree), actualResult.ToArray().OrderBy(x => x.Degree), _polynomialComparer);
        }

        [TestCaseSource("SubtractionPolynomialTuplesTestCases")]
        public void SubtractionByOperator_PolynomialMinusPolynomialTuple_NewPolynomial(Polynomial membersA,
            double degree, double coeff, Polynomial expectedResult)
        {
            // act 
            var actualResult = membersA - (degree, coeff);
            // assert
            AssertIsAsExpected(expectedResult.ToArray().OrderBy(x => x.Degree), actualResult.ToArray().OrderBy(x => x.Degree), _polynomialComparer);
        }

        [TestCaseSource("SubtractionPolynomialTuplesTestCases")]
        public void Subtraction_PolynomialMinusPolynomialTuple_NewPolynomial(Polynomial membersA,
            double degree, double coeff, Polynomial expectedResult)
        {
            // act 
            var actualResult = membersA.Subtraction((degree, coeff));
            // assert
            AssertIsAsExpected(expectedResult.ToArray().OrderBy(x => x.Degree), actualResult.ToArray().OrderBy(x => x.Degree), _polynomialComparer);
        }

        [TestCaseSource("MultiplyPolynomialTuplesTestCases")]
        public void MultiplyByOperator_PolynomialMinusPolynomialTuple_NewPolynomial(Polynomial membersA,
            double degree, double coeff, Polynomial expectedResult)
        {
            // act 
            var actualResult = membersA * (degree, coeff);
            // assert
            AssertIsAsExpected(expectedResult.ToArray().OrderBy(x => x.Degree), actualResult.ToArray().OrderBy(x => x.Degree), _polynomialComparer);
        }

        [TestCaseSource("MultiplyPolynomialTuplesTestCases")]
        public void Multiply_PolynomialMinusPolynomialTuple_NewPolynomial(Polynomial membersA,
            double degree, double coeff, Polynomial expectedResult)
        {
            // act 
            var actualResult = membersA.Multiply((degree, coeff));
            // assert
            AssertIsAsExpected(expectedResult.ToArray().OrderBy(x => x.Degree), actualResult.ToArray().OrderBy(x => x.Degree), _polynomialComparer);
        }
        #endregion

        #region exceptions for tuple
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        public void AddMember_ZeroTuple_ThrowPolynomialArgumentException(double degree, double coefficient)
        {
            // arrange
            var expectedTypeError = typeof(PolynomialArgumentException);
            // act
            Exception ex = Assert.Catch(() => _polynomial.AddMember((degree, coefficient)));
            // assert
            Assert.AreEqual(expectedTypeError, ex.GetType(),
                message: "AddMember method throw PolynomialArgumentException if coefficient is 0 in Tuple. ");
        }

        [TestCase(5, 0)]
        [TestCase(5, 1)]
        public void AddMember_TupleWithContainedDegree_ThrowPolynomialArgumentException(double degree, double coefficient)
        {
            // arrange
            var expectedTypeError = typeof(PolynomialArgumentException);
            // act
            Exception ex = Assert.Catch(() => _polynomial.AddMember(((degree, coefficient))));
            // assert
            Assert.AreEqual(expectedTypeError, ex.GetType(),
                message: "AddMember method throw PolynomialArgumentException if there is element with such coefficient. ");
        }
        #endregion

        #endregion*/

    }

    class PolynomialComparer : IEqualityComparer<PolynomialMember>
    {
        private const double Precision = 0.00001;

        public bool Equals(PolynomialMember expected, PolynomialMember actual)
        {
            if (expected == null && actual == null)
                return true;
            if (expected == null || actual == null)
                return false;

            return Math.Abs(expected.Degree - actual.Degree) < Precision && Math.Abs(expected.Coefficient - actual.Coefficient) < Precision;
        }

        public int GetHashCode([DisallowNull] PolynomialMember obj)
        {
            return obj.GetHashCode();
        }
    }

}
