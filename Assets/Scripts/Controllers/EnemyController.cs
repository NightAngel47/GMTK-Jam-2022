namespace Controllers
{
    public class EnemyController : BaseController
    {
        public static EnemyController Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else
            { 
                Instance = this; 
            }
        }
    }
}