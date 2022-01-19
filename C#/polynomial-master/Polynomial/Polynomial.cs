using System;
using System.Collections.Generic;
using System.Linq;
using PolynomialObject.Exceptions;

namespace PolynomialObject
{
    public sealed class Polynomial
    {
        private readonly List<PolynomialMember> _polynomialLst;

        public Polynomial()
        {
            _polynomialLst = new List<PolynomialMember>();
        }

        public Polynomial(PolynomialMember member)
        {
            _polynomialLst = new List<PolynomialMember>
            {
                member
            };
        }

        public Polynomial(IEnumerable<PolynomialMember> members)
        {
            _polynomialLst = new List<PolynomialMember>(members);
        }

        public Polynomial((double degree, double coefficient) member)
        {
            _polynomialLst = new List<PolynomialMember>();
            _polynomialLst.Add(new PolynomialMember(member.degree, member.coefficient));
        }

        public Polynomial(IEnumerable<(double degree, double coefficient)> members)
        {
            foreach (var m in members)
            {
                var member = new PolynomialMember(m.degree, m.coefficient);
                _polynomialLst.Add(member);
            }
        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (var polym in _polynomialLst)
                {
                    if (polym != null)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        public double Degree
        {
            get
            {
                double max = _polynomialLst[0].Degree;
                for (int i = 1; i < _polynomialLst.Count; i++)
                {
                    if (_polynomialLst[i].Degree > max)
                    {
                        max = _polynomialLst[i].Degree;
                    }
                }
                return max;
            }
        }

        public void AddMember(PolynomialMember member)
        {
            if (member == null)
            {
                throw new PolynomialArgumentNullException();
            }
            else if (member.Coefficient != 0 && !(this.ContainsMember(member.Degree)))
            {
                _polynomialLst.Add(member);
            }
            else if (this.ContainsMember(member.Degree) || member.Coefficient == 0)
            {
                throw new PolynomialArgumentException();
            }
        }

        public void AddMember((double degree, double coefficient) member)
        {
            if (member.coefficient != 0 && !(this.ContainsMember(member.degree)))
            {
                _polynomialLst.Add(new PolynomialMember(member.degree, member.coefficient));
            }
            else if (this.ContainsMember(member.degree) || member.coefficient == 0)
            {
                throw new PolynomialArgumentException();
            }
        }

        public bool RemoveMember(double degree)
        {
            if (_polynomialLst.Exists(m => m?.Degree == degree))
            {
                _polynomialLst.RemoveAll(p => p.Degree == degree);
                return true;
            }
            return false;
        }

        public bool ContainsMember(double degree)
        {
            if (_polynomialLst.Exists(m => m?.Degree == degree))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public PolynomialMember Find(double degree)
        {
            var item = _polynomialLst.First(d => d.Degree == degree);
            return item;
        }

        public double this[double degree]
        {
            get
            {
                var item = _polynomialLst.First(p => p.Degree == degree);
                if (item != null)
                {
                    return item.Coefficient;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (value != 0)
                {
                    if (_polynomialLst.Exists(m => m?.Degree == degree))
                    {
                        _polynomialLst.First(m => m?.Degree == degree).Coefficient = value;
                    }
                    else
                    {
                        _polynomialLst.Add(new PolynomialMember(degree, value));
                    }
                }
                else
                {
                    if (_polynomialLst.Exists(m => m?.Degree == degree))
                    {
                        _polynomialLst.RemoveAll(m => m?.Degree == degree);
                    }
                }
            }
        }

        public PolynomialMember[] ToArray()
        {
            return _polynomialLst.ToArray();
        }

        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            if (a == null || b == null)
            {
                throw new PolynomialArgumentNullException();
            }
            a._polynomialLst.RemoveAll(m => m?.Coefficient == 0);
            b._polynomialLst.RemoveAll(m => m?.Coefficient == 0);
            foreach (var itemB in b._polynomialLst)
            {
                if (!(a.ContainsMember(itemB.Degree)))
                {
                    a.AddMember(new PolynomialMember(itemB.Degree, itemB.Coefficient));
                }
                else if ((a.ContainsMember(itemB.Degree)))
                {
                    a.Find(itemB.Degree).Coefficient += itemB.Coefficient;
                    if (a.Find(itemB.Degree).Coefficient == 0)
                    {
                        a._polynomialLst.Remove(a.Find(itemB.Degree));
                    }
                }
            }
            return a;
        }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            if (a == null || b == null)
            {
                throw new PolynomialArgumentNullException();
            }
            a._polynomialLst.RemoveAll(m => m?.Coefficient == 0);
            b._polynomialLst.RemoveAll(m => m?.Coefficient == 0);
            foreach (var itemB in b._polynomialLst)
            {
                if ((a.ContainsMember(itemB.Degree)))
                {
                    itemB.Coefficient = -itemB.Coefficient;
                    a.Find(itemB.Degree).Coefficient += itemB.Coefficient;
                    if (a.Find(itemB.Degree).Coefficient == 0)
                    {
                        a._polynomialLst.Remove(a.Find(itemB.Degree));
                    }
                }
                else if (!(a.ContainsMember(itemB.Degree)))
                {
                    itemB.Coefficient = -itemB.Coefficient;
                    if (itemB.Coefficient != 0)
                    {
                        a.AddMember(new PolynomialMember(itemB.Degree, itemB.Coefficient));
                    }
                }
            }
            a._polynomialLst.RemoveAll(p => p.Coefficient == 0);
            return a;
        }

        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            if (a == null || b == null)
            {
                throw new PolynomialArgumentNullException();
            }
            Polynomial polynom = new Polynomial();
            foreach (var thisItem in a._polynomialLst)
            {
                foreach (var otherItem in b._polynomialLst)
                {
                    if (thisItem.Coefficient * otherItem.Coefficient != 0 && !polynom.ContainsMember(thisItem.Degree + otherItem.Degree))
                    {
                        polynom.AddMember(new PolynomialMember(thisItem.Degree + otherItem.Degree, thisItem.Coefficient * otherItem.Coefficient));
                    }
                    else if (thisItem.Coefficient * otherItem.Coefficient != 0 && polynom.ContainsMember(thisItem.Degree + otherItem.Degree))
                    {
                        polynom.Find(thisItem.Degree + otherItem.Degree).Coefficient += thisItem.Coefficient * otherItem.Coefficient;
                    }
                    else if (thisItem.Coefficient * otherItem.Coefficient == 0 && polynom.ContainsMember(thisItem.Degree + otherItem.Degree))
                    {
                        polynom._polynomialLst.Remove(polynom.Find(otherItem.Degree));
                    }
                }
            }
            return polynom;
        }

        public Polynomial Add(Polynomial polynomial)
        {
            if (polynomial == null)
            {
                throw new PolynomialArgumentNullException();
            }
            this._polynomialLst.RemoveAll(m => m?.Coefficient == 0);
            polynomial._polynomialLst.RemoveAll(m => m?.Coefficient == 0);
            foreach (var itemB in polynomial._polynomialLst)
            {
                if (itemB != null && !(this.ContainsMember(itemB.Degree)))
                {
                    this.AddMember(new PolynomialMember(itemB.Degree, itemB.Coefficient));
                }
                else if (itemB != null && (this.ContainsMember(itemB.Degree)))
                {
                    this.Find(itemB.Degree).Coefficient += itemB.Coefficient;
                    if (this.Find(itemB.Degree).Coefficient == 0)
                    {
                        this._polynomialLst.Remove(this.Find(itemB.Degree));
                    }
                }
            }
            return this;
        }
        public Polynomial Subtraction(Polynomial polynomial)
        {
            if (polynomial == null)
            {
                throw new PolynomialArgumentNullException();
            }
            foreach (var itemB in polynomial._polynomialLst)
            {
                if ((this.ContainsMember(itemB.Degree)))
                {
                    itemB.Coefficient = -itemB.Coefficient;
                    this.Find(itemB.Degree).Coefficient += itemB.Coefficient;
                    if (this.Find(itemB.Degree).Coefficient == 0)
                    {
                        this._polynomialLst.Remove(this.Find(itemB.Degree));
                    }
                }
                else if (!(this.ContainsMember(itemB.Degree)))
                {
                    itemB.Coefficient = -itemB.Coefficient;
                    if (itemB.Coefficient != 0)
                    {
                        this.AddMember(new PolynomialMember(itemB.Degree, itemB.Coefficient));
                    }
                }
            }
            this._polynomialLst.RemoveAll(p => p.Coefficient == 0);
            return this;
        }

        public Polynomial Multiply(Polynomial polynomial)
        {
            if (polynomial == null)
            {
                throw new PolynomialArgumentNullException();
            }
            Polynomial thisPolynom = new Polynomial(this._polynomialLst);
            Polynomial newPolynom = new Polynomial();

            double currentDegree;
            double currentCoefficient;

            foreach (var thisItem in thisPolynom._polynomialLst)
            {
                foreach (var otherItem in polynomial._polynomialLst)
                {
                    currentDegree = thisItem.Degree + otherItem.Degree;
                    currentCoefficient = thisItem.Coefficient * otherItem.Coefficient;

                    if (currentCoefficient != 0 && !newPolynom.ContainsMember(currentDegree))
                    {
                        newPolynom.AddMember(new PolynomialMember(currentDegree, currentCoefficient));
                    }

                    else if (currentCoefficient != 0 && newPolynom.ContainsMember(currentDegree))
                    {
                        if (otherItem.Coefficient > 0)
                        {
                            newPolynom.Find(currentDegree).Coefficient += otherItem.Coefficient;
                        }
                        else if (otherItem.Coefficient < 0)
                        {
                            newPolynom.Find(currentDegree).Coefficient -= otherItem.Coefficient;
                        }
                    }
                }
            }
            return newPolynom;
        }
        public static Polynomial operator +(Polynomial a, (double degree, double coefficient) b)
        {
            if (a == null)
            {
                throw new PolynomialArgumentNullException();
            }
            var polynomial = new Polynomial(b);
            a._polynomialLst.RemoveAll(m => m?.Coefficient == 0);
            polynomial._polynomialLst.RemoveAll(m => m?.Coefficient == 0);
            foreach (var itemB in polynomial._polynomialLst)
            {
                if (itemB != null && !(a.ContainsMember(itemB.Degree)))
                {
                    a.AddMember(new PolynomialMember(itemB.Degree, itemB.Coefficient));
                }
                else if (itemB != null && (a.ContainsMember(itemB.Degree)))
                {
                    a.Find(itemB.Degree).Coefficient += itemB.Coefficient;
                    if (a.Find(itemB.Degree).Coefficient == 0)
                    {
                        a._polynomialLst.Remove(a.Find(itemB.Degree));
                    }
                }
            }
            return a;
        }

        public static Polynomial operator -(Polynomial a, (double degree, double coefficient) b)
        {
            if (a == null)
            {
                throw new PolynomialArgumentNullException();
            }
            var polynom = new Polynomial(b);
            a._polynomialLst.RemoveAll(m => m?.Coefficient == 0);
            polynom._polynomialLst.RemoveAll(m => m?.Coefficient == 0);
            foreach (var itemB in polynom._polynomialLst)
            {
                if ((a.ContainsMember(itemB.Degree)))
                {
                    itemB.Coefficient = -itemB.Coefficient;
                    a.Find(itemB.Degree).Coefficient += itemB.Coefficient;
                    if (a.Find(itemB.Degree).Coefficient == 0)
                    {
                        a._polynomialLst.Remove(a.Find(itemB.Degree));
                    }
                }
                else if (!(a.ContainsMember(itemB.Degree)))
                {
                    itemB.Coefficient = -itemB.Coefficient;
                    if (itemB.Coefficient != 0)
                    {
                        a.AddMember(new PolynomialMember(itemB.Degree, itemB.Coefficient));
                    }
                }
            }
            a._polynomialLst.RemoveAll(p => p.Coefficient == 0);
            return a;
        }

        public static Polynomial operator *(Polynomial a, (double degree, double coefficient) b)
        {
            var newPolynom = new Polynomial();
            var polynom = new Polynomial(b);
            foreach (var thisItem in a._polynomialLst)
            {
                foreach (var otherItem in polynom._polynomialLst)
                {
                    if (thisItem.Coefficient * otherItem.Coefficient != 0 && !newPolynom.ContainsMember(thisItem.Degree + otherItem.Degree))
                    {
                        newPolynom.AddMember(new PolynomialMember(thisItem.Degree + otherItem.Degree, thisItem.Coefficient * otherItem.Coefficient));
                    }
                    else if (thisItem.Coefficient * otherItem.Coefficient != 0 && newPolynom.ContainsMember(thisItem.Degree + otherItem.Degree))
                    {
                        newPolynom.Find(thisItem.Degree + otherItem.Degree).Coefficient += otherItem.Coefficient;
                    }
                    else if (thisItem.Coefficient * otherItem.Coefficient == 0 && newPolynom.ContainsMember(thisItem.Degree + otherItem.Degree))
                    {
                        newPolynom._polynomialLst.Remove(newPolynom.Find(otherItem.Degree));
                    }
                }
            }
            return newPolynom;
        }

        public Polynomial Add((double degree, double coefficient) member)
        {
            var polynom = new Polynomial(member);
            polynom._polynomialLst.RemoveAll(m => m?.Coefficient == 0);
            this._polynomialLst.RemoveAll(m => m?.Coefficient == 0);
            foreach (var itemB in polynom._polynomialLst)
            {
                if (itemB != null && !(this.ContainsMember(itemB.Degree)))
                {
                    this.AddMember(new PolynomialMember(itemB.Degree, itemB.Coefficient));
                }
                else if (itemB != null && (this.ContainsMember(itemB.Degree)))
                {
                    this.Find(itemB.Degree).Coefficient += itemB.Coefficient;
                    if (this.Find(itemB.Degree).Coefficient == 0)
                    {
                        this._polynomialLst.Remove(this.Find(itemB.Degree));
                    }
                }
            }
            return this;
        }

        public Polynomial Subtraction((double degree, double coefficient) member)
        {

            var polynomial = new Polynomial(member);
            foreach (var itemB in polynomial._polynomialLst)
            {
                if ((this.ContainsMember(itemB.Degree)))
                {
                    itemB.Coefficient = -itemB.Coefficient;
                    this.Find(itemB.Degree).Coefficient += itemB.Coefficient;
                    if (this.Find(itemB.Degree).Coefficient == 0)
                    {
                        this._polynomialLst.Remove(this.Find(itemB.Degree));
                    }
                }
                else if (!(this.ContainsMember(itemB.Degree)))
                {
                    itemB.Coefficient = -itemB.Coefficient;
                    if (itemB.Coefficient != 0)
                    {
                        this.AddMember(new PolynomialMember(itemB.Degree, itemB.Coefficient));
                    }
                }
            }
            this._polynomialLst.RemoveAll(p => p.Coefficient == 0);
            return this;
        }
        public Polynomial Multiply((double degree, double coefficient) member)
        {
            var polynom = new Polynomial(member);
            var newPolynom = new Polynomial();
            double currentDegree;
            double currentCoefficient;

            foreach (var thisItem in this._polynomialLst)
            {
                foreach (var otherItem in polynom._polynomialLst)
                {
                    currentDegree = thisItem.Degree + otherItem.Degree;
                    currentCoefficient = thisItem.Coefficient * otherItem.Coefficient;

                    if (currentCoefficient != 0 && !newPolynom.ContainsMember(currentDegree))
                    {
                        newPolynom.AddMember(new PolynomialMember(currentDegree, currentCoefficient));
                    }

                    else if (currentCoefficient != 0 && newPolynom.ContainsMember(currentDegree))
                    {
                        if (otherItem.Coefficient > 0)
                        {
                            newPolynom.Find(currentDegree).Coefficient += otherItem.Coefficient;
                        }
                        else if (otherItem.Coefficient < 0)
                        {
                            newPolynom.Find(currentDegree).Coefficient -= otherItem.Coefficient;
                        }
                    }
                }
            }
            return newPolynom;
        }
    }
}
