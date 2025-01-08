public interface Observable
{
    public void Attach(Observer observer);
    public void Detach(Observer observer);
    public void Notify();
}
