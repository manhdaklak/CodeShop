using Shop.Data.Repositories;
using Shop.Data.Structure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service
{
    public interface IOrderService
    {
        Order Create(ref Order order, List<OrderDetail> orderDetails);
        void UpdateStatus(int orderId);
        void Save();
    }
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IOrderDetailsRepository _orderDetailsRepository;
        private IUnitWork _unitWork;
        public OrderService(IOrderRepository orderRepository,IOrderDetailsRepository orderDetailsRepository, IUnitWork unitWork)
        {
            this._orderRepository = orderRepository;
            this._orderDetailsRepository = orderDetailsRepository;
            this._unitWork = unitWork;
        }
        public Order Create(ref Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                _orderRepository.Add(order);
                _unitWork.Commit();
                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderID = order.ID;
                    _orderDetailsRepository.Add(orderDetail);
                }
                return order;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Save()
        {
            _unitWork.Commit();
        }

        public void UpdateStatus(int orderId)
        {
            var order = _orderRepository.GetSingleById(orderId);
            order.Status = true;
            _orderRepository.Update(order);
        }
    }
}
