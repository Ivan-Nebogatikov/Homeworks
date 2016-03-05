#include "mainWindow.h"
#include "ui_mainWindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    connect(ui->backButton, SIGNAL(clicked(bool)), ui->webView, SLOT(back()));
    connect(ui->forwardButton, SIGNAL(clicked(bool)), ui->webView, SLOT(forward()));
    connect(ui->webView, SIGNAL(loadProgress(int)), ui->progressOfLoading, SLOT(setValue(int)));
    connect(ui->webView, SIGNAL(linkClicked(QUrl)), this, SLOT(loadPage(QUrl)));
    connect(ui->refreshButton, SIGNAL(clicked(bool)), this, SLOT(on_refreshButton_clicked()));
    connect(ui->urlEdit, SIGNAL(returnPressed()), SLOT(enterPressed()));
    ui->webView->page()->setLinkDelegationPolicy(QWebPage::DelegateAllLinks);
    QString url = "http://www.google.com";
    ui->webView->load(url);
}

void MainWindow::loadPage(QUrl url)
{
    ui->webView->load(url);
    ui->urlEdit->setText(url.toString());
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::textToUrl()
{
    printf("fds");
    if (ui->urlEdit->text().endsWith(".com") || ui->urlEdit->text().endsWith(".ru")
            || ui->urlEdit->text().endsWith(".net"))
    {
        if (ui->urlEdit->text().startsWith("http://www."))
        {
            ui->webView->load(ui->urlEdit->text());
        }
        else
        {
            if (ui->urlEdit->text().startsWith("www."))
            {
                ui->webView->load("http://" + ui->urlEdit->text());
            }
            else
            {
                ui->webView->load("http://www." + ui->urlEdit->text());
            }
        }
    }
    else
    {
        ui->webView->load("http://www.google.ru/#newwindow=1&q=" + ui->urlEdit->text());
    }
}

void MainWindow::on_goButton_clicked()
{
    textToUrl();
}
void MainWindow::enterPressed()
{
    textToUrl();
}

void MainWindow::on_refreshButton_clicked()
{
    ui->webView->load(ui->webView->url());
    ui->urlEdit->setText(ui->webView->url().toString());
}
