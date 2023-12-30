-- Decrease the tax rate by 3% for all payments
UPDATE Payments
SET TaxRate = TaxRate - 0.03 * TaxRate;

-- Select only the TaxRate column from the Payments table
SELECT TaxRate FROM Payments;