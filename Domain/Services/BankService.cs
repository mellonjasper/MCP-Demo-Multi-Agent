///A bank service to handle bank account operations. in this demo class i want just one field balance that can be increased or decreased. based on the operations: withdrwal, deposit, getbalance
/// Do not add the concept of users or accounts.
// just a simple bank service with a balance field and the three operations mentioned before.

namespace Domain.Services;
using System;

public class BankService
{
    private decimal _balance = 0;

    public decimal GetBalance() => _balance;
    public void Deposit(decimal amount) => _balance += amount;
    public void Withdraw(decimal amount) {
        if (amount > _balance)
        {
            throw new InvalidOperationException("Insufficient funds");
        }
        _balance -= amount;
    }
}